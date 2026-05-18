using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;

/// <summary>
/// 商品登録ViewModelを商品Domeinモデルへ変換するAdapterの約束を定義します。
/// ControllerはこのInterfaceを通して画面用データを業務用データへ変換します。
/// </summary>
public interface IItemRegisterViewModelAdapter
{
    Item Restore(ItemRegisterViewModel target);
}
