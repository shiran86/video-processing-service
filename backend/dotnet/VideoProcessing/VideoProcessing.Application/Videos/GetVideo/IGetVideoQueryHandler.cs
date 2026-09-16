

namespace VideoProcessing.Application.Videos.GetVideo
{
    public interface IGetVideoQueryHandler
    {
        Task<GetVideoResponse> Handle(GetVideoQuery query);
    }
}
