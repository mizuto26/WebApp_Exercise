using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;

public class ItemRegisterViewModelAdapter : IRestorer<ItemRegisterViewModel, Item>
{
    public Item Restore(ItemRegisterViewModel target)
    {
        var stock = new ItemStock(target.Stock ?? 0);
        var category = new ItemCategory(target.CategoryId, target.CategoryName);
        var item = new Item(target.Name, target.Price ?? 0);
        item.ChangeItemCategory(category);
        item.ChangeStock(stock);
        return item;
    }
}