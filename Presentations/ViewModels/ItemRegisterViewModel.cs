using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;

/// <summary>
/// 商品登録画面で使うViewModelです。
/// 入力値、確認画面の表示値、カテゴリ選択リストを保持します。
/// </summary>
public class ItemRegisterViewModel
{
    [Required(ErrorMessage = "商品名は必須です。")]
    [StringLength(30, ErrorMessage = "商品名は30文字以内で入力してください。")]
    [Display(Name = "商品名")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "単価は必須です。")]
    [Range(0, int.MaxValue, ErrorMessage = "単価は0以上で入力してください。")]
    [Display(Name = "単価")]
    public int? Price { get; set; }

    [Required(ErrorMessage = "在庫数は必須です。")]
    [Range(0, int.MaxValue, ErrorMessage = "在庫数は0以上で入力してください。")]
    [Display(Name = "在庫数")]
    public int? Stock { get; set; }

    [Required(ErrorMessage = "商品カテゴリを選択してください。")]
    [Display(Name = "商品カテゴリ")]
    public int? CategoryId { get; set; }

    [Display(Name = "カテゴリ名")]
    public string? CategoryName { get; set; } = string.Empty;

    public void SetCategories(List<ItemCategory> categories)
    {
        var categorySelectItems =
            //<select> の <option>1件
            new List<SelectListItem>
            {
                new() {
                    Value = "",
                    Text = "（選択してください）"
                }
            };

        foreach (var category in categories)
        {
            if (!category.Id.HasValue) continue;

            string categoryName;

            if (string.IsNullOrEmpty(category.Name)) categoryName = "(名称未設定)";
            else categoryName = category.Name;

            var selectItem =
                new SelectListItem
                {
                    Value = category.Id.Value.ToString(),
                    Text = categoryName
                };

            categorySelectItems.Add(selectItem);
        }

        Categories = categorySelectItems;
    }

    public List<SelectListItem>? Categories { get; set; } = null;
}
