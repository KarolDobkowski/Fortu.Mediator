using System.Threading.Tasks;

namespace Flowem.Mediator
{
    public interface IMediator
    {
        void Send<TMessage>(TMessage message) where TMessage : IMessage;
        Task<TResult> Dispatch<TMessage, TResult>(TMessage message) where TMessage : IMessage<TResult>;
    }
}