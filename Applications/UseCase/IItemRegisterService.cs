using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Services;

/// <summary>
/// 商品登録機能で必要な業務処理の約束を定義します。
/// ControllerはこのInterfaceを通して商品登録の処理を依頼します。
/// </summary>
public interface IItemRegisterService
{
    List<ItemCategory> GetItemCategories();
    ItemCategory GetItemCategoryById(int id);
    void Exists(string name);
    void Register(Item item);
}
