using VideoProcessing.Domain.Entities;

namespace VideoProcessing.Application.Videos
{
    public interface IVideoRepository
    {
        Task<Video> GetVideoByIdAsync(int id);
    }
}
