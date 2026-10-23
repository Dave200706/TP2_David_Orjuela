using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriVie.Models.NutriVieEF;
using NutriVie.ViewModel;

namespace NutriVie.Controllers
{
    public class StatsController : Controller
    {
        private readonly NutriVieDbContext _context;
        public StatsController(NutriVieDbContext context)
        {
            _context = context;
        }
        // GET: StatsController
        public IActionResult Index()
        {
            var viewModel = new StatVM();

            viewModel.NombreDeRecettesAvec3Aliments = _context.Recettes.Where(r => r.AlimentRecette.Count == 3).Count();
            //viewModel.AlimentPlusCalorique = _context.Aliments.Where(r=>r.AlimentRecette)
            //viewModel.DureePlusCourte = 
            //viewModel.NbCaloriesRecetteFranciase
            return View(viewModel);
        }



        }
}
