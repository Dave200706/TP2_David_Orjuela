using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NutriVie.Models
{
    public class Recette
    {
        [Key]
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Description { get; set; }

        public int TempsPreparation { get; set; }

        public int TempsCuisson { get; set; }

        public string? Image { get; set; }
        [ForeignKey("Categorie")]
        public int CategorieId { get; set; }
        [ValidateNever]
        public Categorie Categorie { get; set; }

    }
}
