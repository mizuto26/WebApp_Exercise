using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Entities;
namespace WebApp_Exercise.Infrastructures.Adapters;

/// <summary>
/// 商品カテゴリドメインモデルとitem_categoryテーブル用Entityを相互変換します。
/// RepositoryがDomainとDBの形を分けて扱うために使います。
/// </summary>
public class ItemCategoryEntityAdapter
: IConverter<ItemCategory, ItemCategoryEntity>, IRestorer<ItemCategoryEntity, ItemCategory>
{
    public ItemCategoryEntity Convert(ItemCategory domain)
    {
        if (domain == null) throw new InternalException("引数domainがnullのため変換できません。");

        ItemCategoryEntity? entity = new();

        if (domain.Id == null) entity.Id = 0;
        else entity.Id = domain.Id.Value;

        entity.Name = domain.Name;
        return entity;
    }

    public ItemCategory Restore(ItemCategoryEntity target)
    {
        if (target == null) throw new InternalException("引数targetがnullのため復元できません。");
        ItemCategory? domain = new(id: target.Id, name: target.Name);
        return domain;
    }
}
