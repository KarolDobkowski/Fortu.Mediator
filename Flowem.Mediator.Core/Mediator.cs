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

        public void Dispatch(IMessage message)
        {
            var handler = ((IMessageHandler<IMessage>) _serviceProvider.GetService(message.GetType()))
                .ThrowExceptionIfNull("Handler cannot be resolved.");
            
            Task.Run(() => handler.Handle(message));
        }

        public async Task<TResult> Dispatch<TResult>(IMessage<TResult> message)
        {
            var handler =
                ((IMessageHandler<IMessage<TResult>, TResult>) _serviceProvider.GetService(message.GetType()))
                .ThrowExceptionIfNull("Handler cannot be resolved.");
            
            return await handler.Handle(message);
        }
    }
}