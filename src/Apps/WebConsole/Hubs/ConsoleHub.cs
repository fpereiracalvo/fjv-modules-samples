using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandPrompt.Web.Modules;
using Fjv.Modules;
using Microsoft.AspNetCore.SignalR;
using WebConsole.Commons;

namespace WebConsole.Hubs
{
    public class ConsoleHub : Hub
    {
        IModuleFactory _moduleFactory;

        public ConsoleHub(
            IModuleFactory moduleFactory)
        {
            _moduleFactory = moduleFactory;

            _moduleFactory.OnModuleExecuting += (sender, e)=>{
                if(e.Module.Module.GetType().Equals(typeof(ExitModule)))
                {
                    Task.Run(async ()=>{
                        await Clients.Caller.SendAsync("Exit", "/");
                    });
                }
            };
        }

        public async Task WriteLine(string command)
        {
            await Clients.Caller.SendAsync("WriteLine", command);
        }

        public async Task PostCommand(string args)
        {
            
            var _args_ = args.Trim().Split(' ');

            var standardOutput = new StreamWriter(Console.OpenStandardOutput());

            using (var writer = new CustomTextWriter(this))
            {
                try
                {
                    Console.SetOut(writer);
                    
                    var buffer = await _moduleFactory.RunAsync(_args_);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.SetOut(standardOutput);
        }
    }
}