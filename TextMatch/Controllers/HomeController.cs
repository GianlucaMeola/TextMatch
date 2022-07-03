using Microsoft.AspNetCore.Mvc;
using TextMatch.Services;

namespace TextMatch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        SerachIndexService serachIndexService = new SerachIndexService();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTextMatch")]
        public IActionResult GetTextMatchIndex(string text, string subtext)
        {
            string res = this.serachIndexService.getSubTextIndex(text, subtext);
            return Ok(res);
        }
    }
}