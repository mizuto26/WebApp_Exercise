using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace WebApp_Exercise.Models;

public class SampleForm
{
    [Display(Name = "氏名")]
    public string? Name { get; set; }

    [Display(Name = "年齢")]
    public int Age { get; set; }

    [Display(Name = "都道府県")]
    public int PrefecturesId { get; set; }

    public List<SelectListItem> PrefecturesList { get; set; } =
    [
        new() { Text="--選択されていません--", Value="0" , Selected = true },
        new() { Text= "北海道", Value= "1" },
        new() { Text= "青森県", Value= "2" },
        new() { Text= "岩手県", Value= "3" },
    ];
}