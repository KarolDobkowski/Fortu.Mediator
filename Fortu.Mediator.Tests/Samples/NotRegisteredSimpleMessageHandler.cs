using System.Threading.Tasks;

namespace Fortu.Mediator.Tests.Samples
{
    public class NotRegisteredSimpleMessageHandler : IMessageHandler<NotRegisteredSimpleMessage>
    {
        public Task Handle(NotRegisteredSimpleMessage message)
            => Task.CompletedTask;
    }
}
