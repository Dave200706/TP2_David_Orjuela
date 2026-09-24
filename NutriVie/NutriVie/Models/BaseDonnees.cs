namespace NutriVie.Models
{
    public class BaseDonnees
    {
        public List<Service> Services { get; set; }

        public BaseDonnees()
        {
            Services = new List<Service>();
        }
    }
}
