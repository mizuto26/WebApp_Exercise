using Microsoft.AspNetCore.Mvc;
namespace WebApp_Exercise.Controllers;

[Route("Exercise04")]
public class Ex04Controller : Controller
{
    [HttpGet("Calc")]
    public IActionResult Calc([FromQuery] int value1, [FromQuery] int value2)
    {
        if (!ModelState.IsValid)
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