namespace VideoProcessing.Application.Clips.CreateClips
{
    public class CreateClipCommand
    {
        public int VideoId { get; set; }
        public List<ClipSegment> Segments { get; set; } = [];

    }
}
