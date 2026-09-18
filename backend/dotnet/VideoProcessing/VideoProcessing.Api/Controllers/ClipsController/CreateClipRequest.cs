namespace VideoProcessing.Api.Controllers.ClipsController
{
    public class CreateClipRequest
    {
        public List<CreateClipSegmentRequest> Segments { get; set; } = [];
    }
}
