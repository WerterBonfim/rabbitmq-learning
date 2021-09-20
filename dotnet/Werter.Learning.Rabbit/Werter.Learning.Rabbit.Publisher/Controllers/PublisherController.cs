using Microsoft.AspNetCore.Mvc;
using Werter.Learning.Rabbit.Models;

namespace Werter.Learning.Rabbit.Publisher.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : ControllerBase
    {
        [HttpPost("publicar")]
        public IActionResult PublishMessage(Letter message)
        {
            return Ok();
        }
    }
}