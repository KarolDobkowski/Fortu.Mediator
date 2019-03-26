namespace Fortu.Mediator.Tests.Samples
{
    public class SimpleMessageWithServiceInjected : IMessage
    {
        public static int _counter { get; set; }

        public int Counter
        {
            get => _counter;
            set => _counter = value;
        }
    }
}
