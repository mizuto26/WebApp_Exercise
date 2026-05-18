using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;

/// <summary>
/// 商品登録ViewModelを商品Domeinモデルへ変換します。
/// 画面で入力された商品名、単価、在庫数、カテゴリをDomainに詰め替えます。
/// </summary>
public class ItemRegisterViewModelAdapter
: IRestorer<ItemRegisterViewModel, Item>
{
    public Item Restore(ItemRegisterViewModel target)
    {
        ItemStock? stock = new(target.Stock ?? 0);
        ItemCategory? category = new(target.CategoryId, target.CategoryName);
        Item? item = new(target.Name, target.Price ?? 0);

        item.ChangeItemCategory(category);
        item.ChangeStock(stock);
        return item;
    }
}
