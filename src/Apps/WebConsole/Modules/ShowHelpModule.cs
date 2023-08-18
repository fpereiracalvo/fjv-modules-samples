using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fjv.Modules;
using Fjv.Modules.Attributes;
using WebConsole.Extensions;

namespace WebConsole.Modules
{
    [Module("--help", Fjv.Modules.Commons.ModuleRunningControl.Input | Fjv.Modules.Commons.ModuleRunningControl.ControlTaker)]
    [ModuleHelp("Show this help message.")]
    public class ShowHelpModule : IDefaultModuleAsync
    {
        IModuleFactory _moduleFactory;
        public ShowHelpModule(IModuleFactory moduleFactory)
        {
            _moduleFactory = moduleFactory;
        }

        public async Task<byte[]> LoadAsync(byte[] input, string[] args, int index)
        {
            var _args_ = args.Where(s=>!s.Equals("--help")).ToArray();
            var message = string.Empty;

            if(_args_.Any())
            {
                message = _moduleFactory.GetHelp(_args_);
            }
            else
            {
                message = _moduleFactory.GetHelp();
            }

            Console.WriteLine($"```bash\n{message}\n```");

            return await Bytes.EmptyAsync();
        }
    }
}