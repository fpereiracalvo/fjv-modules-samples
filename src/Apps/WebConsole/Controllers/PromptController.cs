using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPrompt.Web.Exceptions;
using CommandPrompt.Web.Modules;
using Fjv.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebConsole.Commons;
using WebConsole.Hubs;

namespace CommandPrompt.Web.Controllers
{
    [Route("prompt")]
    public class PromptController : Controller
    {
        private readonly ILogger<PromptController> _logger;
        IModuleFactory _moduleFactory;
        CustomTextWriter _customTextWriter;
        ConsoleHub _consoleHub;

        public class Model
        {
            public string Args { get; set; } = string.Empty;
        }

        public PromptController(
            ILogger<PromptController> logger,
            IModuleFactory moduleFactory,
            CustomTextWriter customTextWriter,
            ConsoleHub consoleHub)
        {
            _logger = logger;
            _moduleFactory = moduleFactory;
            _customTextWriter = customTextWriter;
            _consoleHub = consoleHub;
        }

        [HttpPost]
        [Route("run")]
        public async Task<IActionResult> PostAsync([FromBody] Model model)
        {
            if(!string.IsNullOrEmpty(model.Args))
            {
                var _args_ = model.Args.Trim().Split(' ');

                Console.SetOut(_customTextWriter);

                try
                {
                    var buffer = await _moduleFactory.RunAsync(_args_);

                    return Json(new { ok = true });
                }
                catch (Exception ex)
                {
                    return Json(new { ok = false });
                }
            }

            return Json(new { ok = false });
        }
    }
}