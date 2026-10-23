using System.Collections.Generic;

namespace NutriVie.ViewModels
{
    public class StatVM
    {
        public int NbRecettesTroisAliments { get; set; }
        public AlimentPlusCaloriqueVM AlimentPlusCalorique { get; set; }
        public List<RecetteCourteVM> Top4RecettesCourtes { get; set; }
        public double CaloriesRecetteFrancaiseMoinsCalorique { get; set; } 
    }

    public class AlimentPlusCaloriqueVM
    {
        public string Nom { get; set; }
        public int CaloriesPour100g { get; set; }
    }

    public class RecetteCourteVM
    {
        public string Nom { get; set; }
        public int TempsTotal { get; set; }
    }
}
