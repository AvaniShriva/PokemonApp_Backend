using Microsoft.EntityFrameworkCore;
using PokemonApp.Models.DBModels;

namespace PokemonApp.Data
{
    public class ApplicationdbContext : DbContext
    {
        public ApplicationdbContext()
        {
        }

        public ApplicationdbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<Models.DBModels.Type> TypeTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.DBModels.Type>().HasData(
                new Models.DBModels.Type
                {
                    Id = 1,
                    TypeName = "Fire",
                },
                new Models.DBModels.Type
                {
                    Id = 2,
                    TypeName = "Water",
                },
                new Models.DBModels.Type
                {
                    Id = 3,
                    TypeName = "Fire",
                }
            );
        }

    }
}
