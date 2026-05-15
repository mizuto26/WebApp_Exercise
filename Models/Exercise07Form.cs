using System.ComponentModel.DataAnnotations;
namespace WebApp_Exercise.Models;

public class Exercise07Form
{
    [Display(Name = "値1")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(0, 100, ErrorMessage = "{0}は{1}～{2}までの数字で入力してください。")]
    public int Value1 { get; set; } = 0;

    [Display(Name = "値2")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(0, 100, ErrorMessage = "{0}は{1}～{2}までの数字で入力してください。")]
    public int Value2 { get; set; } = 0;

    public int Answer { get; set; } = 0;
}