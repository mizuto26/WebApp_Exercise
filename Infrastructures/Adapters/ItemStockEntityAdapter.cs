using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Entities;
namespace WebApp_Exercise.Infrastructures.Adapters;

public class ItemStockEntityAdapter :
IConverter<ItemStock, ItemStockEntity>, IRestorer<ItemStockEntity, ItemStock>
{
    public ItemStockEntity Convert(ItemStock domain)
    {
        if (domain == null) throw new InternalException("引数domainがnullのため変換できません。");

        ItemStockEntity entity = new()
        {
            Id = domain.Id ?? 0,
            Stock = domain.Stock,
            ItemId = 0,
            Product = null
        };

        return entity;
    }

    public ItemStock Restore(ItemStockEntity target)
    {
        if (target == null) throw new InternalException("引数targetがnullのため復元できません。");
        return new ItemStock(target.Id, target.Stock ?? 0);
    }
}