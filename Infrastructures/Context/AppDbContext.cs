using Microsoft.EntityFrameworkCore;
using WebApp_Exercise.Infrastructures.Entities;
namespace WebApp_Exercise.Infrastructures.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ItemCategoryEntity> ItemCategories { get; set; }
    public DbSet<ItemEntity> Items { get; set; }
    public DbSet<ItemStockEntity> ItemStocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ItemEntity>()
            .HasOne(ItemEntity => ItemEntity.Category)
            .WithMany(ItemCategoryEntity => ItemCategoryEntity.Items)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ItemEntity>()
            .HasOne(ItemEntity => ItemEntity.Stock)
            .WithOne(ItemStockEntity => ItemStockEntity.Product)
            .OnDelete(DeleteBehavior.Cascade);
    }
}