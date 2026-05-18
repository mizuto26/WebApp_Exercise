using WebApp_Exercise.Applications.Domains;

namespace WebApp_Exercise.Presentations.ViewModels;

public interface IItemRegisterViewModelAdapter
{
    Item Restore(ItemRegisterViewModel target);
}
