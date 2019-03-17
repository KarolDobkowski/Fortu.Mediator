using System.Threading.Tasks;
using Fortu.Mediator.Tests.Messages;

namespace Fortu.Mediator.Tests.Samples
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
