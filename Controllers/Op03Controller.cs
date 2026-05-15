using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Models;
namespace WebApp_Exercise.Controllers;

[Route("Option03")]
public class Op03Controller : Controller
{
    [ValidateAntiForgeryToken]
    [HttpPost("Calc")]
    public IActionResult Calc(Op03Form form)
    {
        int? result = form.Opt switch
        {
            1 => form.Value1 + form.Value2,
            2 => form.Value1 - form.Value2,
            3 => form.Value1 * form.Value2,
            4 => form.Value1 / form.Value2,
            5 => form.Value1 % form.Value2,
            _ => null
        };

        if (result is null)
        {
            return Content("不明な計算種別です。");
        }

        return Content(result.Value.ToString());
    }
}