using System;
using System.Collections.Generic;
using System.Text;
using Flowem.Mediator.Core.Interfaces;

namespace Flowem.Mediator.Tests.GenericMessages
{
    public class SimpleMessage : IMessage<SimpleMessageResult>
    {
        public Guid Guid { get; set; }
    }
}
