using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fjv.Modules;
using Fjv.Modules.Attributes;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebConsole.Extensions;

namespace WebConsole.Modules
{
    [Module("myip")]
    [ModuleHelp("Show my IP address.")]
    public class MyIpModule : IDefaultModuleAsync
    {
        IActionContextAccessor _actionContextAccessor;

        public MyIpModule(IActionContextAccessor actionContextAccessor)
        {
            _actionContextAccessor = actionContextAccessor;
        }

        public async Task<byte[]> LoadAsync(byte[] input, string[] args, int index)
        {
            var ip = _actionContextAccessor.ActionContext?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? throw new Exception("No IP address found.");

            Console.WriteLine($"> IP: {ip}\n");

            return await Bytes.EmptyAsync();
        }
    }
}