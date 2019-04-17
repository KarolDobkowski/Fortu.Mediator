using System.Threading.Tasks;

namespace Fortu.Mediator.Tests.Samples
{
    public class SimpleGenericMessageHandler : IMessageHandler<SimpleGenericMessage, SimpleGenericMessageResult>
    {
        public Task<SimpleGenericMessageResult> Handle(SimpleGenericMessage genericMessage)
            => Task.FromResult(new SimpleGenericMessageResult(genericMessage.Guid.ToString(), 348));
    }
}
