using Microsoft.EntityFrameworkCore;
using MovieCharactersApi.Data.Entities;

namespace MovieCharactersApi.Data;

public class DatabaseContext : DbContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DatabaseContext()
    {
    }

    public virtual DbSet<Character> Characters { get; set; }
    public virtual DbSet<Franchise> Franchises { get; set; }
    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Channel>(entity =>
        //{
        //    entity.HasKey(u => u.Id);

        //    entity.HasOne(a => a.Product)
        //        .WithMany(a => a.ReleaseChannels)
        //        .HasForeignKey(a => a.ProductType)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    entity.HasIndex(u => new { u.Name, u.ProductType }).IsUnique();
        //});

        // After setting up the tables, insert seed data in database.
        SeedData(modelBuilder);
    }

    /// <summary>
    /// Seeds the database with initial data.
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void SeedData(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Product>().HasData(new Product()
        //{
        //    ProductType = productId,
        //    FirmwareId = default
        //});
    }
}