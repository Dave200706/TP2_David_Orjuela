using NutriVie.Models;

namespace NutriVie.ViewModel
{
    public class StatVM
    {
        public int NombreDeRecettesAvec3Aliments { get; set; }

        public string AlimentPlusCalorique { get; set; }

        public List<NomEtTempsREcette> DureePlusCourte { get; set; }

        public int NbCaloriesRecetteFranciase { get; set; }

        
    }
    public class NomEtTempsREcette
        {

            public string Nom { get; set; }
        public int TempsTotal { get; set; }
    }
}
