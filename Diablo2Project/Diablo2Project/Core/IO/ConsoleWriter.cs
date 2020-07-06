using Diablo2Project.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Core.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
