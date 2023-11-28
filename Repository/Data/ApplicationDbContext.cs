using IWantApp.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Repository.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Name).IsRequired();
        modelBuilder.Entity<Product>()
            .Property(p => p.Description).HasMaxLength(255);
        modelBuilder.Entity<Category>()
            .Property(c => c.Name).IsRequired();

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>()
            .HaveMaxLength(100);
        base.ConfigureConventions(configurationBuilder);
    }
}
