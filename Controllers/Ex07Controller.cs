using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Models;
namespace WebApp_Exercise.Controllers;

[Route("Exercise07")]
public class Ex07Controller : Controller
{
    [HttpPost("Calc")]
    public IActionResult Calc(Exercise07Form form)
    {
        int result = form.Value1 + form.Value2;
        return Content($"{form.Value1} + {form.Value2} = {result}");
    }
}