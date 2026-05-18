using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp_Exercise.Infrastructures.Entities;

/// <summary>
/// itemテーブルに対応するEntityです。
/// DB保存・取得時の商品データの形を表します。
/// </summary>
[Table("item")]
public class ItemEntity
{
    [Column("id")]
    public int? Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("price")]
    public int? Price { get; set; }

    [Column("category_id")]
    public int? CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public ItemCategoryEntity? Category { get; set; }

    public ItemStockEntity? Stock { get; set; }
}
