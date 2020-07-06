using Diablo2Project.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Core.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine().Trim();
        }
    }
}
