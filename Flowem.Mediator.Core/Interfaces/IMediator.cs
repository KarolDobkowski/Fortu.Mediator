using System.Threading.Tasks;

namespace Flowem.Mediator.Core.Interfaces
{
    public interface IMediator
    {
        void Dispatch(IMessage message);
        Task<TResult> Dispatch<TResult>(IMessage<TResult> message);
    }
}