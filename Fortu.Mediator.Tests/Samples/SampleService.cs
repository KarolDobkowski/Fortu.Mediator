using System.Threading;

namespace Fortu.Mediator.Tests.Samples
{
    public class SampleService : ISampleService
    {
        public void Execute()
        {
            Thread.Sleep(10);
        }
    }
}
