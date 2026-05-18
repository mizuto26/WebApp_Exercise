using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp_Exercise.Infrastructures.Entities;

[Table("item_stock")]
public class ItemStockEntity
{
    [Column("id")]
    public int? Id { get; set; }

    [Column("stock")]
    public int? Stock { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [ForeignKey("ItemId")]
    public ItemEntity? Product { get; set; }
}