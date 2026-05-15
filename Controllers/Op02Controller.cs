using Microsoft.AspNetCore.Mvc;
namespace WebApp_Exercise.Controllers;

[Route("Option02")]
public class Op02Controller : Controller
{
    [HttpGet("Calc/{value1}/{value2}/{opt}")]
    public IActionResult Calc(int value1, int value2, int opt)
    {
        int? result = opt switch
        {
            1 => value1 + value2,
            2 => value1 - value2,
            3 => value1 * value2,
            4 => value1 / value2,
            5 => value1 % value2,
            _ => (int?)null
        };

        if (result is null)
        {
            return Content("不明な計算種別です。");
        }

        return Content(result.Value.ToString());
    }
}
