using WebApp_Exercise.Exceptions;
namespace WebApp_Exercise.Applications.Domains;

/// <summary>
/// 商品在庫を表すドメインモデルです。
/// 在庫数が0以上であることなど、在庫として守るべき業務ルールを持ちます。
/// </summary>
public class ItemStock
{
    public int? Id { get; private set; }
    public int Stock { get; private set; } = 0;
    public Item? Item { get; private set; } = null;

    public ItemStock(int? id, int stock)
    {
        this.ValidateId(id);
        this.ValidateStock(stock);
        Id = id;
        Stock = stock;
    }

    public ItemStock(int stcok) : this(id: null, stock: stcok) { }

    private void ValidateId(int? id)
    {
        if (id == null) return;
        if (id < 1) throw new DomainException("商品在庫Idは1以上でなければなりません。");
    }

    private void ValidateStock(int stock)
    {
        if (stock < 0) throw new DomainException("商品在庫数は0以上でなければなりません。");
    }

    public void ChangeStock(int stock)
    {
        this.ValidateStock(stock);
        this.Stock = stock;
    }

    public void ChangeProduct(Item? item)
    {
        this.Item = item;
    }



    public override string ToString()
    {
        string idText;
        if (this.Id == null) idText = "未登録";
        else idText = this.Id.ToString()!;

        string itemText;
        if (this.Item == null) itemText = "";
        else itemText = this.Item.ToString();

        return $"商品在庫Id={idText}, " + $"在庫数={Stock}, " + $"商品={itemText}";
    }
}
