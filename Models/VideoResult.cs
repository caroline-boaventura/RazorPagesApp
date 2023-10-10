namespace Razor_Estudos.Models
{
    public class VideoResult
    {
        public string? Format { get; set; }
        public string? HasExternalSubtitles { get; set; }
        public int VideoRate { get; set; }
        public int Duration { get; set; }
        public int Height { get; set; } 
        public string? Is3D { get; set; }
        public string? IsBluRay { get; set; }
        public string? IsDvd { get; set; }
        public string? IsHdr { get; set; }
        public string? IsStreamable { get; set; }
        public long Size { get; set; }
        public string? Subtitles { get; set; }
        public MediaInfo.Model.AudioTags? Tags { get; set; }
        public string? VideoResolution { get; set; }
    }
}