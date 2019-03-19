using System;
using System.Threading.Tasks;
using Fortu.Mediator.Extensions;

namespace Fortu.Mediator
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Send<TMessage>(TMessage message)
            where TMessage : IMessage
        {
            message.ThrowExceptionIfNull("Message cannot be null.");

            var handlerType = typeof(IMessageHandler<>).MakeGenericType(message.GetType());
            var handler = (IMessageHandler<TMessage>)_serviceProvider.GetService(handlerType);
            if (handler is null)
                throw new ArgumentNullException(nameof(handler), "Handler is not registered.");

            Task.Run(() => handler.Handle(message));
        }

        public Task<TResult> Dispatch<TResult>(IMessage<TResult> message)
        {
            message.ThrowExceptionIfNull("Message cannot be null.");

            var handler = _serviceProvider.GetService(typeof(IMessageHandler<,>).MakeGenericType(message.GetType(), typeof(TResult)));
            if (handler is null)
                throw new ArgumentNullException(nameof(handler), "Handler is not registered.");
            
            var handle = handler
                .GetType()
                .GetMethod("Handle");

            return (Task<TResult>)handle.Invoke(handler, new object[]{ message });
        }
    }
}