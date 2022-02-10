using CoureWebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoureWebAPI.Data.Persistence
{
    public class CoureWebDbContext : DbContext
    {
        public CoureWebDbContext(DbContextOptions<CoureWebDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Country> Country { get; set; }
        public DbSet<CountryDetails> CountryDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(150)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoureWebDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}