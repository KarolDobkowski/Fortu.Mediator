using System.Threading.Tasks;

namespace Flowem.Mediator.Core.Interfaces
{
    public interface IMessageHandler<in TMessage, TResult>
        where TMessage : IMessage<TResult>
    {
        Task<TResult> Handle(TMessage message);
    }
    
    public interface IMessageHandler<in TMessage>
        where TMessage : IMessage
    {
        Task Handle(TMessage message);
    }
}