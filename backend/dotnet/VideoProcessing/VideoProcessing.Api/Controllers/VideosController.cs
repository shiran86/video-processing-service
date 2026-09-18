using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoProcessing.Application.Videos.GetVideo;

namespace VideoProcessing.Api.Controllers
{
    [ApiController]
    [Route("api/v1/videos")]
    public class VideosController : ControllerBase
    {
        private readonly IGetVideoQueryHandler _getVideoQueryHandler;
        public VideosController(IGetVideoQueryHandler getVideoQueryHandler) {
            _getVideoQueryHandler = getVideoQueryHandler;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetVideos()
        {
            return Ok("You are authenticated");
        }

        [Authorize]
        [HttpGet("{videoId}")]
        public async Task<IActionResult> GetVideo(int videoId)
        {
            //var usrId = HttpContext.User.Identity;// TODO: add check that user belongs to the video
            var query = new GetVideoQuery(videoId);
            var video = await _getVideoQueryHandler.Handle(query);
            return Ok(video);
        }
    }
}
