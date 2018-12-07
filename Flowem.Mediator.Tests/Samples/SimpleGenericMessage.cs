using System;

namespace Flowem.Mediator.Tests.Samples
{
    public class SimpleGenericMessage : IMessage<SimpleGenericMessageResult>
    {
        public Guid Guid { get; set; }
    }
}
