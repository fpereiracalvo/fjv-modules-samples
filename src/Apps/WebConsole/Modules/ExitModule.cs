using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandPrompt.Web.Exceptions;
using Fjv.Modules;
using Fjv.Modules.Attributes;
using WebConsole.Extensions;

namespace CommandPrompt.Web.Modules
{
    [Module("exit")]
    [ModuleHelp("Exit the console.")]
    public class ExitModule : IDefaultModuleAsync
    {
        public async Task<byte[]> LoadAsync(byte[] input, string[] args, int index)
        {
            return await Bytes.EmptyAsync();
        }
    }
}