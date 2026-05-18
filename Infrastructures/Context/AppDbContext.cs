using Microsoft.EntityFrameworkCore;
using WebApp_Exercise.Infrastructures.Entities;
namespace WebApp_Exercise.Infrastructures.Context;

/// <summary>
/// EF CoreでPostgreSQLへ接続するためのDbContextです。
/// 商品、商品カテゴリ、商品在庫のテーブルとリレーションを設定します。
/// </summary>
public class AppDbContext() : DbContext
{
    public DbSet<ItemCategoryEntity> ItemCategories { get; set; }
    public DbSet<ItemEntity> Items { get; set; }
    public DbSet<ItemStockEntity> ItemStocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ItemEntity>()
            .Property(ItemEntity => ItemEntity.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ItemStockEntity>()
            .Property(ItemStockEntity => ItemStockEntity.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ItemCategoryEntity>()
            .Property(ItemCategoryEntity => ItemCategoryEntity.Id)
            .ValueGeneratedOnAdd();

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
