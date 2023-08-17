using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fjv.Modules;
using Fjv.Modules.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace CommandPrompt.Web.Modules
{
    [Module("--version")]
    [ModuleHelp("Show Fjv Web Console version.")]
    public class VersionModule : IDefaultModuleAsync
    {
        public async Task<byte[]> LoadAsync(byte[] input, string[] args, int index)
        {
            await Task.Run(()=>{
                Console.WriteLine("**Fjv WebConsole v1.0.0-demo.1**\n");
            });

            return new byte[]{};
        }
    }
}