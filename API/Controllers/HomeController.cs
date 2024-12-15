using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(new { Status = "Ok" });
        }
    }
}
