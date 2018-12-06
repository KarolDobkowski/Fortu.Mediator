using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flowem.Mediator.Core.Interfaces;

namespace Flowem.Mediator.Tests.Samples
{
    public class GenericMessageWithValueTypeResponseHandler : IMessageHandler<GenericMessageWithValueTypeResponse, long>
    {
        public Task<long> Handle(GenericMessageWithValueTypeResponse message)
            => Task.FromResult(123456789987654321);
    }
}
