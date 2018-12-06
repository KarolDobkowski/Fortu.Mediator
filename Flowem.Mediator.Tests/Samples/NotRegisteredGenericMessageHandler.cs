using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flowem.Mediator.Core.Interfaces;

namespace Flowem.Mediator.Tests.Samples
{
    public class NotRegisteredGenericMessageHandler : IMessageHandler<NotRegisteredGenericMessage, int>
    {
        public Task<int> Handle(NotRegisteredGenericMessage genericMessage)
            => Task.FromResult(3);
    }
}
