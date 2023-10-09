using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_Estudos.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private IWebHostEnvironment _environment;

    [BindProperty]
    public IFormFile Video { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }

    public void OnGet()
    {

    }

    public void OnPost()
    {
        Console.WriteLine("entrei");

        Console.WriteLine(Video.FileName);
    }
}
