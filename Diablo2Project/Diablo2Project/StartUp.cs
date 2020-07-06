using Diablo2Project.Core;
using Diablo2Project.Core.IO;
using Diablo2Project.Core.IO.Contracts;
using System;

namespace Diablo2Project
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            var engine = new Engine(reader, writer);

            engine.Run();
        }
    }
}
