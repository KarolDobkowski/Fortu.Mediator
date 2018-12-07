namespace Flowem.Mediator.Tests.Samples
{
    public class SimpleMessage : IMessage
    {
        public static int _counter { get; set; }

        public int Counter
        {
            get => _counter; 
            set => _counter = value;
        }
    }
}
