using System;

namespace Flowem.Mediator.Extensions
{
    internal static class MessageExtensions
    {
        internal static IMessage<TResult> ThrowExceptionIfNull<TResult>(this IMessage<TResult> message,
            string exceptionMessage = null)
        {
            if(message is null)
                throw new ArgumentNullException(nameof(message), exceptionMessage);

            return message;
        }

        internal static IMessage ThrowExceptionIfNull(this IMessage message,
            string exceptionMessage = null)
        {
            if(message is null)
                throw new ArgumentNullException(nameof(message), exceptionMessage);

            return message;
        }
    }
}
