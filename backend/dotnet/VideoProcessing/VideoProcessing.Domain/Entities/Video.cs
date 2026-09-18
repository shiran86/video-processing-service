
using VideoProcessing.Domain.Enums;

namespace VideoProcessing.Domain.Entities
{
    public class Video
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string S3Key { get; set; } = string.Empty;

        public VideoStatus Status { get; set; }

        public int? SourceVideoId { get; set; }

    }
}
