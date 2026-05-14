using System.ComponentModel.DataAnnotations;
namespace WebApp_Exercise.Models;

public class Exercise07Form
{
    [Display(Name = "値1")]
    public int Value1 { get; set; } = 0;
    [Display(Name = "値2")]
    public int Value2 { get; set; } = 0;

    public int Answer { get; set; } = 0;
}