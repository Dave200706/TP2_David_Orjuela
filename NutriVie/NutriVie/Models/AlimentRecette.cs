using System.ComponentModel.DataAnnotations;

namespace NutriVie.Models
{
    public class AlimentRecette
    {
        public int RecetteId { get; set; }
        public Recette Recette { get; set; }

        public int AlimentId { get; set; }
        public Aliment Aliment { get; set; }

        [Range(0.1, 10000)]
        public double Poids { get; set; }
    }
}
