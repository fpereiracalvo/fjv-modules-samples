using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebConsole.Modules
{
    public class HelpCommons
    {
        public static string GetPath(string filename)
        {
            return Path.Combine(Environment.CurrentDirectory, "wwwroot", "content", "help", filename);
        }
    }
}