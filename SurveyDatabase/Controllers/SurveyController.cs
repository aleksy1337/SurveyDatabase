using Microsoft.AspNetCore.Mvc;

namespace SurveyDatabase.API.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
