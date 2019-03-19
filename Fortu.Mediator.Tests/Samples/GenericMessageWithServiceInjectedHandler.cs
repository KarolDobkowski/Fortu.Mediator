using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fortu.Mediator.Tests.Samples
{
    public class GenericMessageWithServiceInjectedHandler : IMessageHandler<GenericMessageWithServiceInjected, int>
    {
        private readonly ISampleService _sampleService;

        public GenericMessageWithServiceInjectedHandler(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        public async Task<int> Handle(GenericMessageWithServiceInjected message)
        {
            _sampleService.Execute();
            await Task.CompletedTask;
            return 10;
        }
    }
}
