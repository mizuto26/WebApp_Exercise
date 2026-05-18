using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Entities;
namespace WebApp_Exercise.Infrastructures.Adapters;

public class ItemEntityAdapter : IConverter<Item, ItemEntity>, IRestorer<ItemEntity, Item>
{
    public ItemEntity Convert(Item domain)
    {
        if (domain == null) throw new InternalException("引数domainがnullのため変換できません。");

        ItemEntity entity = new()
        {
            Id = domain.Id,
            Name = domain.Name,
            Price = domain.Price,
            CategoryId = domain.ItemCategory?.Id,
            Category = null,
            Stock = null
        };

        return entity;
    }

    public Item Restore(ItemEntity target)
    {
        if (target == null) throw new InternalException("引数targetがnullのため復元できません。");
        Item? domain = new(target.Id, target.Name, target.Price);
        return domain;
    }
}
