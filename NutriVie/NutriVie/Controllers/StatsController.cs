using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriVie.Models.NutriVieEF;
using NutriVie.ViewModels;

namespace NutriVie.Controllers
{
    public class StatsController : Controller
    {
        private readonly NutriVieDbContext _context;

        public StatsController(NutriVieDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new StatVM();

            
            viewModel.NbRecettesTroisAliments = _context.Recettes
                .Where(r => r.AlimentRecette.Count == 3)
                .Count();

           
            viewModel.AlimentPlusCalorique = _context.Aliments
                .OrderByDescending(a => a.CaloriesPour100g)
                .Select(a => new AlimentPlusCaloriqueVM
                {
                    Nom = a.Nom,
                    CaloriesPour100g = (int)a.CaloriesPour100g
                })
                .FirstOrDefault();

          
            viewModel.Top4RecettesCourtes = _context.Recettes
                .OrderBy(r => r.TempsPreparation + r.TempsCuisson)
                .Select(r => new RecetteCourteVM
                {
                    Nom = r.Nom,
                    TempsTotal = r.TempsPreparation + r.TempsCuisson
                })
                .Take(4)
                .ToList();

            
            var requeteCaloriesFrancaises = _context.Recettes
                .Where(r => r.Nom == "Française" || r.Nom == "France") 
                .Select(r => r.AlimentRecette.Sum(ar => (ar.Poids / 100.0) * ar.Aliment.CaloriesPour100g));

            if (requeteCaloriesFrancaises.Any())
            {
               
                viewModel.CaloriesRecetteFrancaiseMoinsCalorique = requeteCaloriesFrancaises.Min();
            }

            return View(viewModel);
        }
    }
}
