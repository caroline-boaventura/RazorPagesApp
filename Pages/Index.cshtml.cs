using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediaInfo;
using Razor_Estudos.Models;

namespace Razor_Estudos.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private IWebHostEnvironment _environment;

    [BindProperty]
    public IFormFile Video { get; set; }

    public Models.JsonResult VideoResult { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        try
        {
            if (Video != null)
            {
                var uploadsDir = Path.Combine(_environment.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsDir);
                var videoPath = Path.Combine(uploadsDir, Video.FileName);

                using (var stream = new FileStream(videoPath, FileMode.Create))
                {
                    Video.CopyTo(stream);
                }

                var videoResult = VideoProcessing(videoPath);

                VideoResult = new Models.JsonResult{ Success = true, Data = videoResult };

                Console.WriteLine(VideoResult);

                return Page();

                // return new JsonResult(new { Success = true, Data = videoResult });
            }
            else 
            {
                VideoResult = new Models.JsonResult{ Success = false, ErrorMessage = "Vídeo não carregado" };
                return Page();
            }
        }
        catch (Exception ex)
        {
            
            VideoResult = new Models.JsonResult{ErrorMessage = ex.Message, Success = false };
            throw;
        }
    }

    private VideoResult VideoProcessing(string videoPath)
    {
        var media = new MediaInfoWrapper(videoPath, _logger);

        if (media.Success)
        {
            VideoResult videoResult = new VideoResult
            {
                Format = media.Format,
                HasExternalSubtitles = media.HasExternalSubtitles ? "Sim" : "Não",
                VideoRate = media.VideoRate,
                Duration = media.Duration,
                Height = media.Height,
                Is3D = media.Is3D ? "Sim" : "Não",
                IsBluRay = media.IsBluRay ? "Sim" : "Não",
                IsDvd = media.IsDvd ? "Sim" : "Não",
                IsHdr = media.IsHdr ? "Sim" : "Não",
                IsStreamable = media.IsStreamable ? "Sim" : "Não",
                Size = media.Size,
                Subtitles = media.Subtitles.Count > 0 ? "Sim" : "Não",
                Tags = media.Tags,
                VideoResolution = media.VideoResolution,
            };

            return videoResult;
        }

        return new VideoResult();
    }
}
