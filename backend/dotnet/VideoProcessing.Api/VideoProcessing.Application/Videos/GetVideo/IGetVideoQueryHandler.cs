

namespace VideoProcessing.Application.Videos.GetVideo
{
    public interface IGetVideoQueryHandler
    {
        GetVideoResponse Handle(GetVideoQuery query);
    }
}
