using System.Text;
using Fjv.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CommandPrompt.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    IModuleFactory _moduleFactory;

    public class PromptModel
    {
        public string Arguments { get; set; } = string.Empty;

        public bool HasArguments()
        {
            return Arguments != null && Arguments.Length > 0;
        }
    }

    [BindProperty]
    public PromptModel Prompt { get; set; } = new PromptModel();

    public IndexModel(
        ILogger<IndexModel> logger,
        IModuleFactory moduleFactory)
    {
        _logger = logger;
        _moduleFactory = moduleFactory;
    }

    public async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}
