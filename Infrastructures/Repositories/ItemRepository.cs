using Microsoft.EntityFrameworkCore;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Adapters;
using WebApp_Exercise.Infrastructures.Context;
namespace WebApp_Exercise.Infrastructures.Repositories;


public class ItemRepository(
    AppDbContext appDbContext,
    ItemEntityAdapter itemAdapter,
    ItemStockEntityAdapter stockAdapter)
: IItemRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;
    private readonly ItemEntityAdapter _itemAdapter = itemAdapter;
    private readonly ItemStockEntityAdapter _stockAdapter = stockAdapter;

    public bool ExistsByName(string name)
    {
        try
        {
            return _appDbContext.Items.Any(i => i.Name == name);
        }
        catch (Exception exception)
        {
            throw new InternalException("引数に指定された商品名の存在有無を取得できませんでした。", exception);
        }
    }

    public Item? FindById(int id)
    {
        try
        {
            var entity = _appDbContext.Items
                        .Include(ItemEntity => ItemEntity.Stock)
                        .FirstOrDefault(ItemEntity => ItemEntity.Id == id);

            if (entity == null) { return null; }

            var item = _itemAdapter.Restore(entity);

            if (entity.Stock != null)
            {
                var stock = _stockAdapter.Restore(entity.Stock);
                stock.ChangeProduct(item);
                item.ChangeStock(stock);
            }
            return item;
        }
        catch (Exception e)
        {
            throw new InternalException("引数Idに一致する商品を取得できませんでした。", e);
        }
    }

    public void Create(Item item)
    {
        try
        {
            var itemEntity = _itemAdapter.Convert(item);
            _appDbContext.Items.Add(itemEntity);
            _appDbContext.SaveChanges();


            if (item.ItemStock != null)
            {
                var stockEntity = _stockAdapter.Convert(item.ItemStock);
                stockEntity.ItemId = (int)itemEntity.Id!;
                _appDbContext.ItemStocks.Add(stockEntity);
                _appDbContext.SaveChanges();
            }
        }
        catch (Exception exception)
        {
            throw new InternalException("商品を永続化できませんでした。", exception);
        }
    }
}