using System.Threading.Tasks;

namespace Fortu.Mediator.Tests.Samples
{
    public class GenericMessageWithValueTypeResponseHandler : IMessageHandler<GenericMessageWithValueTypeResponse, long>
    {
        public Task<long> Handle(GenericMessageWithValueTypeResponse message)
            => Task.FromResult(123456789987654321);
    }
}
