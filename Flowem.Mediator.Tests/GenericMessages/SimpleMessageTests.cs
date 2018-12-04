using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Flowem.Mediator.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Flowem.Mediator.Tests.GenericMessages
{
    public class SimpleMessageTests
    {
        protected readonly IMediator _mediator;

        public SimpleMessageTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IMessageHandler<SimpleMessage, SimpleMessageResult>, SimpleMessageHandler>();
            var provider = services.BuildServiceProvider();

            _mediator = new Core.Mediator(provider);
        }

        [Fact]
        public async Task dfgd()
        {
            var message = new SimpleMessage()
            {
                Guid = Guid.NewGuid()
            };

            var result = await _mediator.Dispatch<SimpleMessage, SimpleMessageResult>(message);

            Assert.IsType<SimpleMessageResult>(result);
            Assert.Equal(message.Guid.ToString(), result.Guid);
        }
    }
}
