using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flowem.Mediator.Core.Interfaces;

namespace Flowem.Mediator.Tests.GenericMessages
{
    public class SimpleMessageHandler : IMessageHandler<SimpleMessage, SimpleMessageResult>
    {
        public async Task<SimpleMessageResult> Handle(SimpleMessage message)
        {
            return new SimpleMessageResult(message.Guid.ToString(), 348);
        }
    }
}
