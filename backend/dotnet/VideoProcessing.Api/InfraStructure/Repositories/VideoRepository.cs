using VideoProcessing.Application.Videos;
using VideoProcessing.Domain.Entities;
using VideoProcessing.Domain.Enums;

namespace VideoProcessing.Infrastructure.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        public Video GetVideoById(int id)
        {
            return new Video
            {
                Id = id,
                Name = "Test Video",
                S3Key = $"videos/{id}/original.mp4",
                Status = VideoStatus.Ready
            };
        }
    }
}
