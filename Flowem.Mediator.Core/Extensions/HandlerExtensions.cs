using System;
using Flowem.Mediator.Core.Interfaces;

namespace Flowem.Mediator.Core.Extensions
{
    public static class HandlerExtensions
    {
        public static IMessageHandler<TMessage, TResult> ThrowExceptionIfNull<TMessage, TResult>(
            this IMessageHandler<TMessage, TResult> handler, string message = null) where TMessage : IMessage<TResult>
        {
            if(handler is null)
                throw new ArgumentException(nameof(handler), message);

            return handler;
        }
        
        public static IMessageHandler<TMessage> ThrowExceptionIfNull<TMessage>(
            this IMessageHandler<TMessage> handler, string message = null) where TMessage : IMessage
        {
            if(handler is null)
                throw new ArgumentException(nameof(handler), message);

            return handler;
        }
    }
}