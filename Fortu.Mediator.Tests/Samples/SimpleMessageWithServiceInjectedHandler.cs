using System.Threading.Tasks;
using Fortu.Mediator.Tests.Messages;

namespace Fortu.Mediator.Tests.Samples
{
    public class SimpleMessageWithServiceInjectedHandler : IMessageHandler<SimpleMessageWithServiceInjected>
    {
        private readonly ISampleService _sampleService;

        public SimpleMessageWithServiceInjectedHandler(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        public Task Handle(SimpleMessageWithServiceInjected message)
        {
            message.Counter++;
            MessagesTests._semaphoreSlim_2.Release();
            _sampleService.Execute();
            return Task.CompletedTask;
        }
    }
}
