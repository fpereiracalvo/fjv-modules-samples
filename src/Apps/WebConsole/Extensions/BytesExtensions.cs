using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebConsole.Extensions
{
    public static class Bytes
    {
        public static async Task<byte[]> EmptyAsync()
        {
            return await Task.Run(() => { return new byte[]{}; });
        }
    }
}