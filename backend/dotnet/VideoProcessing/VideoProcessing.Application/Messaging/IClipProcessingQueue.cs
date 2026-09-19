using VideoProcessing.Application.Clips.CreateClips;

namespace VideoProcessing.Application.Messaging
{
    public interface IClipProcessingQueue
    {
        Task EnqueueAsync(CreateClipCommand command);
    }
}
