namespace Flowem.Mediator.Tests.GenericMessages
{
    public class SimpleMessageResult
    {
        public string Guid { get; set; }
        public int Const { get; set; }

        public SimpleMessageResult(string guid, int @const)
        {
            Guid = guid;
            Const = @const;
        }
    }
}
