using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fjv.Modules;
using Fjv.Modules.Attributes;
using WebConsole.Extensions;
using WebConsole.Modules;

namespace CommandPrompt.Web.Modules
{
    [Module("--about")]
    [ModuleHelp("Show Fjv Web Console about.")]
    public class AboutModule : IDefaultModuleAsync
    {
        public async Task<byte[]> LoadAsync(byte[] input, string[] args, int index)
        {
            Console.WriteLine(File.ReadAllText(HelpCommons.GetPath("about.md")));

            return await Bytes.EmptyAsync();
        }
    }
}