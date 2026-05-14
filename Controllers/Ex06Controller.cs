using Microsoft.AspNetCore.Mvc;
namespace WebApp_Exercise.Controllers;

[Route("Exercise06")]
public class Ex06Controller : Controller
{
    [HttpGet("Calc/{value1}/{value2}")]
    public IActionResult Calc(int value1, int value2)
    {
        if (!ModelState.IsValid) // 型変換エラー?
        {
            if ((ModelState["value1"]?.Errors.Count ?? 0) > 0 && (ModelState["value2"]?.Errors.Count ?? 0) > 0)
            {
                return Content("value1とvalue2は整数ではありません。");
            }
            if ((ModelState["value1"]?.Errors.Count ?? 0) > 0)
            {
                return Content("value1は整数ではありません。");
            }
            if ((ModelState["value2"]?.Errors.Count ?? 0) > 0)
            {
                return Content("value2は整数ではありません。");
            }
        }
        var result = value1 + value2;
        return Content($"{value1} + {value2} = {result}");
    }
}