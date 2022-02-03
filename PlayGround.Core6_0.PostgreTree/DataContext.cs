using Microsoft.EntityFrameworkCore;

namespace PlayGround.Core6_0.PostgreTree
{
    internal class DataContext : DbContext
    {
        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host=localhost:5432;Database=tree10;Username=postgres;Password={Pass.Password}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("ltree");
        }

        public DbSet<File> Files { get; set;}
    }
}
