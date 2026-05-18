using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Context;
namespace WebApp_Exercise.Applications.Services.Impls;

/// <summary>
/// 商品登録機能の業務処理を担当します。
/// 商品名の重複確認、カテゴリ取得、商品登録のトランザクション制御を行います。
/// </summary>
public class ItemRegisterService(
    AppDbContext context,
    IItemRepository itemRepository,
    IItemCategoryRepository itemCategoryRepository)
: IItemRegisterService
{
    private readonly AppDbContext _context = context;
    private readonly IItemRepository _itemRepository = itemRepository;
    private readonly IItemCategoryRepository _itemCategoryRepository = itemCategoryRepository;

    public List<ItemCategory> GetItemCategories()
    {
        return _itemCategoryRepository.FindAll();
    }

    public ItemCategory GetItemCategoryById(int id)
    {
        var result = _itemCategoryRepository.FindById(id)
            ?? throw new NotFoundException($"指定されたId:{id}の商品カテゴリは存在しません。");
        return result;
    }

    public void Exists(string name)
    {
        bool exists = _itemRepository.ExistsByName(name);
        if (exists) throw new ExistsException($"商品名:{name}は既に存在します。");
    }

    public void Register(Item item)
    {
        try
        {
            _context.Database.BeginTransaction();
            _itemRepository.Create(item);
            _context.Database.CommitTransaction();

        }
        catch
        {
            _context.Database.RollbackTransaction();
            throw;
        }
    }
}
