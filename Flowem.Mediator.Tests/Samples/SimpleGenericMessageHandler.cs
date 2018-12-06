using System.Threading.Tasks;
using Flowem.Mediator.Core.Interfaces;

namespace Flowem.Mediator.Tests.Samples
{
    public class SimpleGenericMessageHandler : IMessageHandler<SimpleGenericMessage, SimpleGenericMessageResult>
    {
        public Task<SimpleGenericMessageResult> Handle(SimpleGenericMessage genericMessage)
            => Task.FromResult(new SimpleGenericMessageResult(genericMessage.Guid.ToString(), 348));
    }
}
