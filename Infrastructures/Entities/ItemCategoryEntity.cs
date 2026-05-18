using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp_Exercise.Infrastructures.Entities;

/// <summary>
/// item_categoryテーブルに対応するEntityです。
/// DB保存・取得時の商品カテゴリデータの形を表します。
/// </summary>
[Table("item_category")]
public class ItemCategoryEntity
{
    [Column("id")]
    public int? Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    public List<ItemEntity>? Items { get; set; }
}
