using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Repositories;

public interface IItemRepository
{
    Item? FindById(int id);
    bool ExistsByName(string name);
    void Create(Item item);
}