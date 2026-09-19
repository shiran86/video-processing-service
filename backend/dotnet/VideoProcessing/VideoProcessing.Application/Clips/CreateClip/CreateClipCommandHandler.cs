using VideoProcessing.Application.Messaging;

namespace VideoProcessing.Application.Clips.CreateClips
{
    public class CreateClipCommandHandler : ICreateClipCommandHandler
    {
        private readonly IClipProcessingQueue _clipProcessingQueue;
        public CreateClipCommandHandler(IClipProcessingQueue clipProcessingQueue)
        {
            _clipProcessingQueue = clipProcessingQueue;
        }

        public Task Handle(CreateClipCommand command)
        {
           return _clipProcessingQueue.EnqueueAsync(command);
        }
    }
}
