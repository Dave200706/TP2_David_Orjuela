using Microsoft.AspNetCore.Mvc;

namespace NutriVie.Controllers
{
    public class RecetteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
