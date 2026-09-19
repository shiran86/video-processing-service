using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoProcessing.Application.Clips;
using VideoProcessing.Application.Clips.CreateClips;
using VideoProcessing.Domain.Entities;

namespace VideoProcessing.Api.Controllers.ClipsController
{
    [Authorize]
    [ApiController]
    [Route("api/v1/videos/{videoId}/clips")]
    public class ClipsController : ControllerBase
    {
        private readonly ICreateClipCommandHandler _createClipsCommandHandler;
        public ClipsController(ICreateClipCommandHandler createClipsCommandHandler)
        {
            _createClipsCommandHandler = createClipsCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int videoId, [FromBody] CreateClipRequest request)
        {
            var command = new CreateClipCommand
            {
                VideoId = videoId,
                Segments = request.Segments
           .Select(x => new ClipSegment
           {
               StartTime = x.StartTime,
               EndTime = x.EndTime
           })
           .ToList()
            };
            await _createClipsCommandHandler.Handle(command);
            return Ok();
        }
    }
}
