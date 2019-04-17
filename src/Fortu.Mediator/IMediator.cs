using System.Threading.Tasks;

namespace Fortu.Mediator
{
    public interface IMediator
    {
        void Send<TMessage>(TMessage message) where TMessage: IMessage;

        Task<TResult> Dispatch<TResult>(IMessage<TResult> message);
    }
}