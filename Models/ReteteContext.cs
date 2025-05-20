using System.Data.Entity;

namespace MRSTWeb.Models
{
    public class ReteteContext : DbContext
    {
        public ReteteContext() : base("name=ReteteContext")
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
} 