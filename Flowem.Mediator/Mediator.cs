using System;
using System.Threading.Tasks;
using Flowem.Mediator.Extensions;

namespace Flowem.Mediator
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

            var handlerType = typeof(IMessageHandler<>).MakeGenericType(typeof(TMessage));
            var handler = ((IMessageHandler<TMessage>)_serviceProvider.GetService(handlerType))
                .ThrowExceptionIfNull("Handler is not registered.");
            
            Task.Run(() => handler.Handle(message));
        }

        public async Task<TResult> Dispatch<TMessage, TResult>(TMessage message) 
            where TMessage : IMessage<TResult>
        {
            message.ThrowExceptionIfNull("Message cannot be null.");

            var handlerType = typeof(IMessageHandler<,>).MakeGenericType(typeof(TMessage), typeof(TResult));
            var handler = ((IMessageHandler<TMessage, TResult>)_serviceProvider.GetService(handlerType))
                .ThrowExceptionIfNull("Handler is not registered.");
            
            return await handler.Handle(message);
        }
    }
}