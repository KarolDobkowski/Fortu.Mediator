using System;
using Flowem.Mediator.Core.Interfaces;

namespace Flowem.Mediator.Core.Extensions
{
    public static class HandlerExtensions
    {
        public static IMessageHandler<IMessage<TResult>, TResult> ThrowExceptionIfNull<TResult>(
            this IMessageHandler<IMessage<TResult>, TResult> handler, string message = null)
        {
            if(handler is null)
                throw new ArgumentException(nameof(handler), message);

            return handler;
        }
        
        public static IMessageHandler<IMessage> ThrowExceptionIfNull(
            this IMessageHandler<IMessage> handler, string message = null)
        {
            if(handler is null)
                throw new ArgumentException(nameof(handler), message);

            return handler;
        }
    }
}