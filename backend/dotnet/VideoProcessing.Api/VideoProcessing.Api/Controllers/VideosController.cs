using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VideoProcessing.Api.Controllers
{
    [ApiController]
    [Route("api/videos")]
    public class VideosController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetVideos()
        {
            return Ok("You are authenticated");
        }
    }
}
