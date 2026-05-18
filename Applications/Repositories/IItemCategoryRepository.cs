using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Repositories;

/// <summary>
/// 商品カテゴリデータの取得に必要なDB操作の約束を定義します。
/// Application層はこのInterfaceに依存し、具体的なDB実装には依存しません。
/// </summary>
public interface IItemCategoryRepository
{
    List<ItemCategory> FindAll();
    ItemCategory? FindById(int id);
}
