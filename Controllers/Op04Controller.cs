using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Models;
namespace WebApp_Exercise.Controllers;

[Route("Option04")]
public class Op04Controller : Controller
{
    [HttpGet("Enter")]
    public ActionResult Enter()
    {
        var form = new Op03Form();
        return View("Enter", form);
    }

    [HttpPost("Result")]
    public IActionResult Result(Op03Form form)
    {
        if (!ModelState.IsValid)
        {
            return View("Enter", form);
        }

        var result = form.Opt switch
        {
            1 => form.Value1 + form.Value2,
            2 => form.Value1 - form.Value2,
            3 => form.Value1 * form.Value2,
            4 => form.Value1 / form.Value2,
            5 => form.Value1 % form.Value2,
            _ => null
        };

        form.Answer = result;
        return View("Result", form);
    }

    [HttpGet("Back")]
    public IActionResult Back()
    {
        var form = new Op03Form();
        return View("Enter", form);
    }
}
