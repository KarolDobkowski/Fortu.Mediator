using System;
using Flowem.Mediator.Core.Interfaces;

namespace Flowem.Mediator.Core.Extensions
{
    public static class HandlerExtensions
    {
        public static IMessageHandler<TMessage, TResult> ThrowExceptionIfNull<TMessage, TResult>(
            this IMessageHandler<TMessage, TResult> handler, string exceptionMessage = null) where TMessage : IMessage<TResult>
        {
            if(handler is null)
                throw new ArgumentNullException(nameof(handler), exceptionMessage);

            return handler;
        }
        
        public static IMessageHandler<TMessage> ThrowExceptionIfNull<TMessage>(
            this IMessageHandler<TMessage> handler, string exceptionMessage = null) where TMessage : IMessage
        {
            if(handler is null)
                throw new ArgumentNullException(nameof(handler), exceptionMessage);

            return handler;
        }
    }
}