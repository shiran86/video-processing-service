using VideoProcessing.Domain.Entities;

namespace VideoProcessing.Application.Videos
{
    public interface IVideoRepository
    {
        Video GetVideoById (int id);
    }
}
