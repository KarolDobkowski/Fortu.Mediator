using System;

namespace Fortu.Mediator.Extensions
{
    internal static class HandlerExtensions
    {
        internal static IMessageHandler<TMessage, TResult> ThrowExceptionIfNull<TMessage, TResult>(
            this IMessageHandler<TMessage, TResult> handler, string exceptionMessage = null) where TMessage : IMessage<TResult>
        {
            if(handler is null)
                throw new ArgumentNullException(nameof(handler), exceptionMessage);

            return handler;
        }
        
        internal static IMessageHandler<TMessage> ThrowExceptionIfNull<TMessage>(
            this IMessageHandler<TMessage> handler, string exceptionMessage = null) where TMessage : IMessage
        {
            if(handler is null)
                throw new ArgumentNullException(nameof(handler), exceptionMessage);

            return handler;
        }
    }
}