using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using Flowem.Mediator.Core.Interfaces;

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
