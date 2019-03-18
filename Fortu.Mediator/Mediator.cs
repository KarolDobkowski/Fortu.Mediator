using System;
using System.Reflection;
using System.Threading.Tasks;
using Fortu.Mediator.Extensions;
using Microsoft.CSharp;

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
            var handler = ((IMessageHandler<TMessage>)_serviceProvider.GetService(handlerType));
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

            var handlerType = handler.GetType();
            var handlerInstance = Activator.CreateInstance(handlerType);
            var handle = handlerType.GetMethod("Handle") ?? throw new InvalidOperationException();
            return (Task<TResult>)handle.Invoke(handlerInstance, new object[]{ message });
        }
    }
}