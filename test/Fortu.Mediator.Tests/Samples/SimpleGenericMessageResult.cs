namespace Fortu.Mediator.Tests.Samples
{
    public class SimpleGenericMessageResult
    {
        public string Guid { get; set; }
        public int Const { get; set; }

        public SimpleGenericMessageResult(string guid, int @const)
        {
            Guid = guid;
            Const = @const;
        }
    }
}