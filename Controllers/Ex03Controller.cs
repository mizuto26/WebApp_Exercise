using Microsoft.AspNetCore.Mvc;
namespace WebApp_Exercise.Controllers;

[Route("Exercise03")]
public class Ex03Controller : Controller
{
    [HttpGet("Morning")]
    public IActionResult Goodmorning()
    {
        return Content("おはようございます。");
    }

    [HttpGet("Evening")]
    public IActionResult Goodevening()
    {
        return Content("こんばんは。");
    }
}