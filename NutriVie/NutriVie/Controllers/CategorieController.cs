using Microsoft.AspNetCore.Mvc;

namespace NutriVie.Controllers
{
    public class CategorieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
