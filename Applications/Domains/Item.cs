using WebApp_Exercise.Exceptions;
namespace WebApp_Exercise.Applications.Domains;

/// <summary>
/// 商品を表すドメインモデルです。
/// 商品名や価格など、商品として守るべき業務ルールを持ちます。
/// </summary>
public class Item
{
    public int? Id { get; private set; }
    public string? Name { get; private set; } = string.Empty;
    public int? Price { get; private set; } = 0;
    public ItemCategory? ItemCategory { get; private set; } = null;
    public ItemStock? ItemStock { get; private set; } = null;

    public Item(int? id, string? name, int? price)
    {
        this.ValidateId(id);
        this.ValidateName(name);
        this.ValidatePrice(price);
        Id = id;
        Name = name;
        Price = price;
    }

    public Item(string? name, int? price) : this(null, name, price) { }

    private void ValidateId(int? id)
    {
        if (id == null) return;
        if (id < 1) throw new DomainException("商品Idは1以上でなければなりません。");
    }

    private void ValidateName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new DomainException("商品名は必須です。");
        if (name.Length > 30) throw new DomainException("商品名は30文字以内で指定してください。");
    }

    private void ValidatePrice(int? price)
    {
        if (price == null) return;
        if (price < 0) throw new DomainException("価格は0以上でなければなりません。");
    }

    public void ChangeName(string? name)
    {
        this.ValidateName(name);
        this.Name = name;
    }

    public void ChangePrice(int price)
    {
        this.ValidatePrice(price);
        this.Price = price;
    }

    public void ChangeItemCategory(ItemCategory? itemCategory)
    {
        this.ItemCategory = itemCategory;
    }

    public void ChangeStock(ItemStock? stock)
    {
        this.ItemStock = stock;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not Item other) return false;
        return this.Id == other.Id;
    }

    public override int GetHashCode()
    {
        if (this.Id == null) return 0;
        return this.Id.GetHashCode();
    }

    public override string ToString()
    {
        string idText;
        if (this.Id == null) idText = "未登録";
        else idText = this.Id.ToString()!;

        string nameText;
        if (string.IsNullOrWhiteSpace(this.Name)) nameText = "未登録";
        else nameText = this.Name;

        string priceText;
        if (this.Price == null) priceText = "未登録";
        else priceText = this.Price.ToString()!;

        string categoryText;
        if (this.ItemCategory == null) categoryText = "未登録";
        else categoryText = this.ItemCategory.ToString();

        string stockText;
        if (this.ItemStock == null) stockText = "未登録";
        else stockText = this.ItemStock.ToString();

        return $"商品Id={idText}, " +
                $"商品名={nameText}, " +
                $"単価={priceText}, " +
                $"商品カテゴリ={categoryText}, " +
                $"商品在庫={stockText}";
    }
}
