namespace VideoProcessing.Application.Clips.CreateClips
{
    public class CreateClipCommandHandler : ICreateClipCommandHandler
    {
        public CreateClipCommandHandler()
        {
        }

        public Task<CreateClipResponse> Handle(CreateClipCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
