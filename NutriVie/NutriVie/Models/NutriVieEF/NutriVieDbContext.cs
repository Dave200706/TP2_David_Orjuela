using Microsoft.EntityFrameworkCore;

namespace NutriVie.Models.NutriVieEF
{
    public class NutriVieDbContext: DbContext
    {
        public NutriVieDbContext(DbContextOptions<NutriVieDbContext> options): base(options)
        {

        }
    }
}
