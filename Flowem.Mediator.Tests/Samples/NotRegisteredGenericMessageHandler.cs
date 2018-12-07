using System.Threading.Tasks;

namespace Flowem.Mediator.Tests.Samples
{
    public class NotRegisteredGenericMessageHandler : IMessageHandler<NotRegisteredGenericMessage, int>
    {
        public Task<int> Handle(NotRegisteredGenericMessage genericMessage)
            => Task.FromResult(3);
    }
}
