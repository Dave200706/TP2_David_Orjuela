using Microsoft.EntityFrameworkCore;

namespace NutriVie.Models.NutriVieEF
{
    public class NutriVieDbContext: DbContext
    {
        public NutriVieDbContext(DbContextOptions<NutriVieDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(
                new Service() { Id = 1, NomDuService= "Recette Saines", Description = "Des recettes équilibrées et faciles à préparer pour toute la famille."},
                new Service() { Id= 2, NomDuService = "Plans Nutritionnels", Description = "Des plans alimentaire personnalisés par nos nutritioniste"},
                new Service() { Id= 3, NomDuService = "Conseils d'Experts", Description = "Des articles et guides sur la nutrition et le bien-être"}
                );
        }
        public DbSet<Service> Services { get; set; }

    }
}
