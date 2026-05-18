using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Services;

public interface IItemRegisterService
{
    List<ItemCategory> GetItemCategories();
    ItemCategory GetItemCategoryById(int id);
    void Exists(string name);
    void Register(Item item);
}