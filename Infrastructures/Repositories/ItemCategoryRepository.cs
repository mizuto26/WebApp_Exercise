using Microsoft.EntityFrameworkCore;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Adapters;
using WebApp_Exercise.Infrastructures.Context;
namespace WebApp_Exercise.Infrastructures.Repositories;

/// <summary>
/// 商品カテゴリデータをPostgreSQLから取得するRepository実装です。
/// IItemCategoryRepositoryの約束をEF CoreとAppDbContextで実現します。
/// </summary>
public class ItemCategoryRepository(
    AppDbContext appDbContext,
    ItemCategoryEntityAdapter adapter)
: IItemCategoryRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;
    private readonly ItemCategoryEntityAdapter _adapter = adapter;


    public List<ItemCategory> FindAll()
    {
        try
        {
            var entities = _appDbContext.ItemCategories
                .AsNoTracking()
                .ToList();

            List<ItemCategory> itemCategories = [];
            foreach (var entity in entities)
            {
                itemCategories.Add(_adapter.Restore(entity));
            }
            return itemCategories;
        }
        catch (Exception exception)
        {
            throw new InternalException(message: "すべての商品カテゴリを取得できませんでした。", exception);
        }
    }

    public ItemCategory? FindById(int id)
    {
        try
        {
            var entity = _appDbContext.ItemCategories
                .Where(ItemCategoryEntity => ItemCategoryEntity.Id == id)
                .FirstOrDefault();

            if (entity == null) return null;
            return _adapter.Restore(entity);
        }
        catch (Exception exception)
        {
            throw new InternalException(message: "引数Idに一致する商品カテゴリを取得できませんでした。", exception);
        }
    }
}
