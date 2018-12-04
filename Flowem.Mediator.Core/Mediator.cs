using System;
using System.Threading.Tasks;
using Flowem.Mediator.Core.Extensions;
using Flowem.Mediator.Core.Interfaces;

namespace Flowem.Mediator.Core
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
            var handlerType = typeof(IMessageHandler<>).MakeGenericType(typeof(TMessage));
            var handler = ((IMessageHandler<TMessage>)_serviceProvider.GetService(handlerType))
                .ThrowExceptionIfNull("Handler is not registered.");
            
            Task.Run(() => handler.Handle(message));
        }

        public async Task<TResult> Dispatch<TMessage, TResult>(TMessage message) 
            where TMessage : IMessage<TResult>
        {
            var handlerType = typeof(IMessageHandler<,>).MakeGenericType(typeof(TMessage), typeof(TResult));
            var handler = ((IMessageHandler<TMessage, TResult>)_serviceProvider.GetService(handlerType))
                .ThrowExceptionIfNull("Handler is not registered.");
            
            return await handler.Handle(message);
        }
    }
}