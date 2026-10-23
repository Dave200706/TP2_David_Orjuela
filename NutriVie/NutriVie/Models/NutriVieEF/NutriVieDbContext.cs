using Microsoft.EntityFrameworkCore;

namespace NutriVie.Models.NutriVieEF
{
    public class NutriVieDbContext: DbContext
    {
        public NutriVieDbContext(DbContextOptions<NutriVieDbContext> options) : base(options)
        {

        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Recette> Recettes { get; set; }
        public DbSet<Aliment> Aliments { get; set; }
        public DbSet<AlimentRecette> AlimentRecettes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(
                new Service() { Id = 1, NomDuService= "Recette Saines", Description = "Des recettes équilibrées et faciles à préparer pour toute la famille."},
                new Service() { Id= 2, NomDuService = "Plans Nutritionnels", Description = "Des plans alimentaire personnalisés par nos nutritioniste"},
                new Service() { Id= 3, NomDuService = "Conseils d'Experts", Description = "Des articles et guides sur la nutrition et le bien-être"}
                );
            modelBuilder.Entity<Categorie>().HasData(
           new Categorie() { Id = 1, Nom = "Française" },
           new Categorie() { Id = 2, Nom = "Indienne" },
           new Categorie() { Id = 3, Nom = "Africaine" },
           new Categorie() { Id = 4, Nom = "Italienne" },
           new Categorie() { Id = 5, Nom = "Orientale" });

            modelBuilder.Entity<Recette>().HasData(
                    new Recette() { Id = 1, Nom = "Boeuf bourguignon", Description = "Ragoût traditionnel français au boeuf et vin rouge.", TempsPreparation = 30, TempsCuisson = 180, Image = "Boeuf_bourguignon.jpg", CategorieId = 1 },
                    new Recette() { Id = 2, Nom = "Quiche lorraine", Description = "Tarte salée avec bacon, oeufs et fromage.", TempsPreparation = 20, TempsCuisson = 45, Image = "Quiche_loraine.jpg", CategorieId = 1 },
                    new Recette() { Id = 3, Nom = "Poulet tikka masala", Description = "Poulet mariné dans une sauce crémeuse épicée.", TempsPreparation = 40, TempsCuisson = 35, Image = "Poulet_tikka_masala.jpg", CategorieId = 2 },
                    new Recette() { Id = 4, Nom = "Poulet au beurre", Description = "Poulet tendre dans une sauce tomate et beurre.", TempsPreparation = 25, TempsCuisson = 40, Image = "Poulet_au_beurre.jpg", CategorieId = 2 },
                    new Recette() { Id = 5, Nom = "Poulet yassa", Description = "Poulet mariné au citron et aux oignons.", TempsPreparation = 35, TempsCuisson = 50, Image = "Poulet_Yassa.jpg", CategorieId = 3 },
                    new Recette() { Id = 6, Nom = "Riz jaune", Description = "accompagnement traditionnel en Afrique du Sud.", TempsPreparation = 10, TempsCuisson = 25, Image = "Riz_jaune.jpg", CategorieId = 3 },
                    new Recette() { Id = 7, Nom = "Lasagne", Description = "Pâtes gratinées avec viande et sauce tomate.", TempsPreparation = 45, TempsCuisson = 60, Image = "Lasagne.jpg", CategorieId = 4 },
                    new Recette() { Id = 8, Nom = "Risotto aux champignons", Description = "Riz crémeux italien aux champignons.", TempsPreparation = 15, TempsCuisson = 35, Image = "Risotto_Champignons.jpg", CategorieId = 4 },
                    new Recette() { Id = 9, Nom = "Couscous Royal", Description = "Semoule servie avec légumes et viandes variées.", TempsPreparation = 40, TempsCuisson = 90, Image = "Couscous_royal.jpg", CategorieId = 5 },
                    new Recette() { Id = 10, Nom = "Shawarma", Description = "Viande marinée grillée servie dans un pain pita.", TempsPreparation = 25, TempsCuisson = 30, Image = "Shawarma.jpg", CategorieId = 5 });
            modelBuilder.Entity<Aliment>().HasData(
                        new Aliment() { Id = 1, Nom = "Boeuf", CaloriesPour100g = 250 },
                        new Aliment() { Id = 2, Nom = "Vin rouge", CaloriesPour100g = 85 },
                        new Aliment() { Id = 3, Nom = "Carottes", CaloriesPour100g = 41 },
                        new Aliment() { Id = 4, Nom = "Oignons", CaloriesPour100g = 40 },
                        new Aliment() { Id = 5, Nom = "Bacon", CaloriesPour100g = 541 },
                        new Aliment() { Id = 6, Nom = "Oeufs", CaloriesPour100g = 155 },
                        new Aliment() { Id = 7, Nom = "Fromage gruyère", CaloriesPour100g = 413 },
                        new Aliment() { Id = 8, Nom = "Crème fraîche", CaloriesPour100g = 292 },
                        new Aliment() { Id = 9, Nom = "Poulet", CaloriesPour100g = 165 },
                        new Aliment() { Id = 10, Nom = "Sauce tomate", CaloriesPour100g = 35 },
                        new Aliment() { Id = 11, Nom = "Épices tikka", CaloriesPour100g = 282 },
                        new Aliment() { Id = 12, Nom = "Yogourt", CaloriesPour100g = 61 },
                        new Aliment() { Id = 13, Nom = "Beurre", CaloriesPour100g = 717 },
                        new Aliment() { Id = 14, Nom = "Citron", CaloriesPour100g = 29 },
                        new Aliment() { Id = 15, Nom = "Riz", CaloriesPour100g = 130 },
                        new Aliment() { Id = 16, Nom = "Curcuma", CaloriesPour100g = 354 },
                        new Aliment() { Id = 17, Nom = "Pâtes à lasagne", CaloriesPour100g = 371 },
                        new Aliment() { Id = 18, Nom = "Viande hachée", CaloriesPour100g = 254 },
                        new Aliment() { Id = 19, Nom = "Champignons", CaloriesPour100g = 22 },
                        new Aliment() { Id = 20, Nom = "Bouillon de poulet", CaloriesPour100g = 8 },
                        new Aliment() { Id = 21, Nom = "Semoule", CaloriesPour100g = 360 },
                        new Aliment() { Id = 22, Nom = "Courgettes", CaloriesPour100g = 17 },
                        new Aliment() { Id = 23, Nom = "Pois chiches", CaloriesPour100g = 364 },
                        new Aliment() { Id = 24, Nom = "Pain pita", CaloriesPour100g = 275 },
                        new Aliment() { Id = 25, Nom = "Tahini", CaloriesPour100g = 595 }
                    );
            modelBuilder.Entity<AlimentRecette>().HasKey(ra => new { ra.RecetteId, ra.AlimentId });

            modelBuilder.Entity<AlimentRecette>().HasData(
                    // Boeuf bourguignon (Id=1)
                    new AlimentRecette() { RecetteId = 1, AlimentId = 1, Poids = 800 },  // Boeuf
                    new AlimentRecette() { RecetteId = 1, AlimentId = 2, Poids = 500 },  // Vin rouge
                    new AlimentRecette() { RecetteId = 1, AlimentId = 3, Poids = 200 },  // Carottes
                    new AlimentRecette() { RecetteId = 1, AlimentId = 4, Poids = 150 },  // Oignons

                    // Quiche lorraine (Id=2)
                    new AlimentRecette() { RecetteId = 2, AlimentId = 5, Poids = 200 },  // Bacon
                    new AlimentRecette() { RecetteId = 2, AlimentId = 6, Poids = 3 },  // Oeufs
                    new AlimentRecette() { RecetteId = 2, AlimentId = 7, Poids = 100 },  // Fromage gruyère
                    new AlimentRecette() { RecetteId = 2, AlimentId = 8, Poids = 200 },  // Crème fraîche

                    // Poulet tikka masala (Id=3)
                    new AlimentRecette() { RecetteId = 3, AlimentId = 9, Poids = 600 },  // Poulet
                    new AlimentRecette() { RecetteId = 3, AlimentId = 10, Poids = 300 },  // Sauce tomate
                    new AlimentRecette() { RecetteId = 3, AlimentId = 11, Poids = 30 },  // Épices tikka
                    new AlimentRecette() { RecetteId = 3, AlimentId = 12, Poids = 150 },  // Yogourt

                    // Poulet au beurre (Id=4)
                    new AlimentRecette() { RecetteId = 4, AlimentId = 9, Poids = 600 },  // Poulet
                    new AlimentRecette() { RecetteId = 4, AlimentId = 13, Poids = 80 },  // Beurre
                    new AlimentRecette() { RecetteId = 4, AlimentId = 10, Poids = 250 },  // Sauce tomate
                    new AlimentRecette() { RecetteId = 4, AlimentId = 8, Poids = 100 },  // Crème fraîche

                    // Poulet yassa (Id=5)
                    new AlimentRecette() { RecetteId = 5, AlimentId = 9, Poids = 700 },  // Poulet
                    new AlimentRecette() { RecetteId = 5, AlimentId = 14, Poids = 2 },  // Citron
                    new AlimentRecette() { RecetteId = 5, AlimentId = 4, Poids = 300 },  // Oignons

                    // Riz jaune (Id=6)
                    new AlimentRecette() { RecetteId = 6, AlimentId = 15, Poids = 400 },  // Riz
                    new AlimentRecette() { RecetteId = 6, AlimentId = 16, Poids = 5 },  // Curcuma
                    new AlimentRecette() { RecetteId = 6, AlimentId = 13, Poids = 30 },  // Beurre

                    // Lasagne (Id=7)
                    new AlimentRecette() { RecetteId = 7, AlimentId = 17, Poids = 300 },  // Pâtes à lasagne
                    new AlimentRecette() { RecetteId = 7, AlimentId = 18, Poids = 500 },  // Viande hachée
                    new AlimentRecette() { RecetteId = 7, AlimentId = 10, Poids = 400 },  // Sauce tomate
                    new AlimentRecette() { RecetteId = 7, AlimentId = 7, Poids = 150 },  // Fromage gruyère

                    // Risotto aux champignons (Id=8)
                    new AlimentRecette() { RecetteId = 8, AlimentId = 15, Poids = 350 },  // Riz
                    new AlimentRecette() { RecetteId = 8, AlimentId = 19, Poids = 300 },  // Champignons
                    new AlimentRecette() { RecetteId = 8, AlimentId = 20, Poids = 500 },  // Bouillon de poulet
                    new AlimentRecette() { RecetteId = 8, AlimentId = 13, Poids = 50 },  // Beurre

                    // Couscous royal (Id=9)
                    new AlimentRecette() { RecetteId = 9, AlimentId = 21, Poids = 500 },  // Semoule
                    new AlimentRecette() { RecetteId = 9, AlimentId = 9, Poids = 300 },  // Poulet
                    new AlimentRecette() { RecetteId = 9, AlimentId = 22, Poids = 200 },  // Courgettes
                    new AlimentRecette() { RecetteId = 9, AlimentId = 23, Poids = 150 },  // Pois chiches

                    // Shawarma (Id=10)
                    new AlimentRecette() { RecetteId = 10, AlimentId = 9, Poids = 500 }, // Poulet
                    new AlimentRecette() { RecetteId = 10, AlimentId = 24, Poids = 2 }, // Pain pita
                    new AlimentRecette() { RecetteId = 10, AlimentId = 25, Poids = 50 }, // Tahini
                    new AlimentRecette() { RecetteId = 10, AlimentId = 4, Poids = 100 }  // Oignons
                );
        }

        

    }
}
