using Microsoft.AspNetCore.Mvc;

namespace BE_thesis.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
