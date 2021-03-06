﻿using System;
using System.Threading.Tasks;
using Fortu.Mediator.Tests.Samples;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fortu.Mediator.Tests.GenericMessages
{
    public class GenericMessagesTests
    {
        protected readonly IMediator _mediator;

        public GenericMessagesTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IMessageHandler<SimpleGenericMessage, SimpleGenericMessageResult>, SimpleGenericMessageHandler>();
            services.AddTransient<IMessageHandler<GenericMessageWithValueTypeResponse, long>, GenericMessageWithValueTypeResponseHandler>();
            services.AddTransient<IMessageHandler<GenericMessageWithServiceInjected, int>, GenericMessageWithServiceInjectedHandler>();
            services.AddTransient<ISampleService, SampleService>();
            var provider = services.BuildServiceProvider();

            _mediator = new Mediator(provider);
        }

        [Fact]
        public async Task ShouldThrowArgumentNullExceptionWhenMessageIsNull()
        {
            SimpleGenericMessage genericMessage = null;
            
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await _mediator.Dispatch(genericMessage));
        }

        [Fact]
        public async Task ShouldThrowArgumentNullExceptionWhenHandlerNotRegistered()
        {
            var message = new NotRegisteredGenericMessage();

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await _mediator.Dispatch(message));
        }

        [Fact]
        public async Task ShouldCorrectlyReturnResult()
        {
            var message = new SimpleGenericMessage()
            {
                Guid = Guid.NewGuid()
            };

            var result = await _mediator.Dispatch(message);

            Assert.IsType<SimpleGenericMessageResult>(result);
            Assert.Equal(message.Guid.ToString(), result.Guid);
            Assert.Equal(348, result.Const);
        }

        [Fact]
        public async Task ShouldCorrectlyReturnValueTypeResult()
        {
            var message = new GenericMessageWithValueTypeResponse();

            var result = await _mediator.Dispatch(message);

            Assert.IsType<long>(result);
            Assert.Equal(123456789987654321, result);
        }

        [Fact]
        public async Task ShouldCorrectlyDispatchHandlerWithParameterInjected()
        {
            var message = new GenericMessageWithServiceInjected();

            var result = await _mediator.Dispatch(message);

            Assert.IsType<int>(result);
            Assert.Equal(10, result);
        }
    }
}
