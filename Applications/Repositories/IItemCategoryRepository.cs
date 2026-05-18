using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Repositories;

public interface IItemCategoryRepository
{
    List<ItemCategory> FindAll();
    ItemCategory? FindById(int id);
}