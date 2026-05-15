using Microsoft.AspNetCore.Mvc;
namespace WebApp_Exercise.Controllers;

[Route("Option01")]
public class Op01Controller : Controller
{
    [HttpGet("Calc")]
    public IActionResult Calc([FromQuery] int value1, [FromQuery] int value2, [FromQuery] int opt)
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
