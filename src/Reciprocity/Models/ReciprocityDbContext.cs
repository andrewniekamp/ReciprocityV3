using Microsoft.EntityFrameworkCore;

namespace Reciprocity.Models
{
    public class ReciprocityDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public ReciprocityDbContext(DbContextOptions<ReciprocityDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
