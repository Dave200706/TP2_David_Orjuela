using System.ComponentModel.DataAnnotations;

namespace NutriVie.Models
{
    public class Service
    {
        
        public int Id { get; set; }
        
        public string NomDuService { get; set; }

        public string Description { get; set; }

    }
}
