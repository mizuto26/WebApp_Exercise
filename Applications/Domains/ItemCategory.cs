using WebApp_Exercise.Exceptions;
namespace WebApp_Exercise.Applications.Domains;

/// <summary>
/// 商品カテゴリを表すドメインモデルです。
/// カテゴリ名など、商品カテゴリとして守るべき業務ルールを持ちます。
/// </summary>
public class ItemCategory
{
    public int? Id { get; private set; }
    public string? Name { get; private set; } = string.Empty;

    public ItemCategory(int? id, string? name)
    {
        this.ValidateId(id);
        this.ValidateName(name);
        Id = id;
        Name = name;
    }

    public ItemCategory(string? name) : this(id: null, name: name) { }
    public ItemCategory(int? id) : this(id: id, name: null) { }

    private void ValidateId(int? id)
    {
        if (id == null) return;
        if (id < 1) throw new DomainException("商品カテゴリIdは1以上でなければなりません。");
    }

    private void ValidateName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new DomainException("商品カテゴリ名は必須です。");
        if (name.Length > 20) throw new DomainException("商品カテゴリ名は20文字以内で指定してください。");

    }

    public void ChangeName(string? name)
    {
        this.ValidateName(name);
        this.Name = name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(objA: this, objB: obj)) return true;
        if (obj is not ItemCategory other) return false;
        return this.Id == other.Id;
    }

    public override int GetHashCode()
    {
        if (Id == null) return 0;
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

        return $"商品カテゴリId={idText}, " + $"商品カテゴリ名={nameText}";
    }
}
