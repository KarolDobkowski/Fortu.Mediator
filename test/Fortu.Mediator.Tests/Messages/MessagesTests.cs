using System;
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
        public static readonly SemaphoreSlim _semaphoreSlim_1 = new SemaphoreSlim(1);
        public static readonly SemaphoreSlim _semaphoreSlim_2 = new SemaphoreSlim(1);

        public MessagesTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IMessageHandler<SimpleMessage>, SimpleMessageHandler>();
            services.AddTransient<IMessageHandler<SimpleMessageWithServiceInjected>, SimpleMessageWithServiceInjectedHandler>();
            services.AddTransient<ISampleService, SampleService>();
            var provider = services.BuildServiceProvider();

            _mediator = new Mediator(provider);
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionWhenMessageIsNull()
        {
            SimpleMessage message = null;

            Assert.Throws<ArgumentNullException>(() => _mediator.Send(message));
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionWhenHandlerNotRegistered()
        {
            var message = new NotRegisteredSimpleMessage();

            Assert.Throws<ArgumentNullException>(() => _mediator.Send(message));
        }

        [Fact]
        public async Task ShouldSendMessagesTwice()
        {
            SimpleMessage._counter = 0;
            var shouldBe_0 = SimpleMessage._counter;
            await _semaphoreSlim_1.WaitAsync();
            _mediator.Send(new SimpleMessage());
            await _semaphoreSlim_1.WaitAsync();
            _mediator.Send(new SimpleMessage());
            await _semaphoreSlim_1.WaitAsync();
            var shouldBe_2 = SimpleMessage._counter;
            _semaphoreSlim_1.Release();

            Assert.Equal(0, shouldBe_0);
            Assert.Equal(2, shouldBe_2);
        }

        [Fact]
        public async Task ShouldSendMessagesWithParameterInjected()
        {
            SimpleMessageWithServiceInjected._counter = 0;
            var shouldBe_0 = SimpleMessageWithServiceInjected._counter;
            await _semaphoreSlim_2.WaitAsync();
            _mediator.Send(new SimpleMessageWithServiceInjected());
            await _semaphoreSlim_2.WaitAsync();
            var shouldBe_1 = SimpleMessageWithServiceInjected._counter;
            _semaphoreSlim_2.Release();

            Assert.Equal(0, shouldBe_0);
            Assert.Equal(1, shouldBe_1);
        }

    }
}
