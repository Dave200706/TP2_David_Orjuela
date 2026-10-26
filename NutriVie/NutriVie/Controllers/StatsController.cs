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

            //Recette des 3 aliment
            viewModel.NbRecettesTroisAliments = _context.Recettes.Where(r => r.AlimentRecette.Count == 3).Count();
            //Aliment le plus calorique
            viewModel.AlimentPlusCalorique = _context.Aliments.OrderByDescending(a => a.CaloriesPour100g).Select(a => new AlimentPlusCaloriqueVM
            {
                Nom = a.Nom,
                CaloriesPour100g = (int)a.CaloriesPour100g
            }).FirstOrDefault();
            //Top des 4 recettes les plus courtes
            viewModel.Top4RecettesCourtes = _context.Recettes.OrderBy(r => r.TempsCuisson + r.TempsPreparation).Select(r => new RecetteCourteVM
            {
                Nom = r.Nom,
                TempsTotal = r.TempsPreparation + r.TempsCuisson
            }).Take(4).ToList();
            //Requete calorique
            var requeteCaloriesFrancaises = _context.Recettes.Where(r=>r.Categorie.Nom == "Française")              
     .Select(r => r.AlimentRecette.Sum(ar => (ar.Poids / 100.0) * ar.Aliment.CaloriesPour100g));

            if (requeteCaloriesFrancaises.Any())
            {
                viewModel.CaloriesRecetteFrancaiseMoinsCalorique = requeteCaloriesFrancaises.Min();
            }


            return View(viewModel);
        }
    }
}
