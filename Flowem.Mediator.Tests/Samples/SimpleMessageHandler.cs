﻿using System.Threading.Tasks;
using Flowem.Mediator.Tests.Messages;

namespace Flowem.Mediator.Tests.Samples
{
    public class SimpleMessageHandler : IMessageHandler<SimpleMessage>
    {
        public Task Handle(SimpleMessage message)
        {
            message.Counter++;
            MessagesTests._semaphoreSlim.Release();
            return Task.CompletedTask;
        }
    }
}