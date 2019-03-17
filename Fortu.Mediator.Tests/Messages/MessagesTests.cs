using System.Threading;
using System.Threading.Tasks;
using Fortu.Mediator.Tests.Samples;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fortu.Mediator.Tests.Messages
{
    public class MessagesTests
    {
        protected readonly IMediator _mediator;
        public static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1);

        public MessagesTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IMessageHandler<SimpleMessage>, SimpleMessageHandler>();
            var provider = services.BuildServiceProvider();

            _mediator = new Mediator(provider);
        }

        [Fact]
        public async Task ShouldSendMessagesTwice()
        {
            SimpleMessage._counter = 0;
            var shouldBe_0 = SimpleMessage._counter;
            await _semaphoreSlim.WaitAsync();
            _mediator.Send(new SimpleMessage());
            await _semaphoreSlim.WaitAsync();
            _mediator.Send(new SimpleMessage());
            await _semaphoreSlim.WaitAsync();
            var shouldBe_2 = SimpleMessage._counter;
            _semaphoreSlim.Release();

            Assert.Equal(0, shouldBe_0);
            Assert.Equal(2, shouldBe_2);
        }

    }
}
