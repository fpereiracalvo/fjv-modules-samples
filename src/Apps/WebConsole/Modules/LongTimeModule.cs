using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fjv.Modules;
using Fjv.Modules.Attributes;
using WebConsole.Extensions;

namespace WebConsole.Modules
{
    [Module("time")]
    [ModuleHelp("Show the current time.")]
    public class LongTimeModule : IDefaultModuleAsync
    {
        public async Task<byte[]> LoadAsync(byte[] input, string[] args, int index)
        {
            return await Bytes.EmptyAsync();
        }

        [Option("--times", true)]
        [OptionHelp("Number of times to show the time. Parameters: times, delay.")]
        public async Task<byte[]> ShowTime(int times, int delay)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));

                await Task.Delay(delay);
            }

            return await Bytes.EmptyAsync();
        }

        [Option("--help")]
        [OptionHelp("Show times help.")]
        public async Task<byte[]> Help()
        {
            Console.WriteLine("Example: > time --times 5 1000");
            
            return await Bytes.EmptyAsync();
        }
    }
}