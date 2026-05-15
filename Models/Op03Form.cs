using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp_Exercise.Models;

public class Op03Form
{
    //バリデーションの指示
    [Display(Name = "値1")]
    [Required(ErrorMessage = "{0}を入力してください。")]
    [Range(0, 1000, ErrorMessage = "{0}は{1}以上{2}以下の範囲で入力してください。")]
    public int? Value1 { get; set; }

    [Display(Name = "値2")]
    [Required(ErrorMessage = "{0}を入力してください。")]
    [Range(0, 1000, ErrorMessage = "{0}は{1}以上{2}以下の範囲で入力してください。")]
    public int? Value2 { get; set; }

    [Display(Name = "計算の種類")]
    [Required(ErrorMessage = "{0}を選択してください。")]
    [Range(1, 5, ErrorMessage = "計算の種類が選択されていません")]
    public int? Opt { get; set; }

    public int? Answer { get; set; }

    public List<SelectListItem> OptList { get; set; } =
    [
        new() { Text="--選択されていません--", Value="0" , Selected = true },
        new() { Text= "加算", Value= "1" },
        new() { Text= "減算", Value= "2" },
        new() { Text= "乗算", Value= "3" },
        new() { Text= "減算", Value= "4" },
        new() { Text= "乗算", Value= "5" }
    ];
}
