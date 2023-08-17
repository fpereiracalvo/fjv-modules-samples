using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebConsole.Hubs;

namespace WebConsole.Commons
{
    public class CustomTextWriter : TextWriter
    {
        ConsoleHub _consoleHub;

        public CustomTextWriter(ConsoleHub consoleHub)
            : base()
        {
            _consoleHub = consoleHub;
        }

        public override Encoding Encoding => throw new NotImplementedException();

        public override void WriteLine(string? value)
        {
            Task.Run(async () => await _consoleHub.WriteLine(value ?? string.Empty));
        }

        public override void Write(string? value)
        {
            Task.Run(async () => await _consoleHub.WriteLine(value ?? string.Empty));
        }
    }
}