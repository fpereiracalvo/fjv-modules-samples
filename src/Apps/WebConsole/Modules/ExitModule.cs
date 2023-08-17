using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandPrompt.Web.Exceptions;
using Fjv.Modules;
using Fjv.Modules.Attributes;

namespace CommandPrompt.Web.Modules
{
    [Module("exit")]
    [ModuleHelp("Exit the console.")]
    public class ExitModule : IDefaultModuleAsync
    {
        public Task<byte[]> LoadAsync(byte[] input, string[] args, int index)
        {
            return Task.FromResult<byte[]>(new byte[0]);
        }
    }
}