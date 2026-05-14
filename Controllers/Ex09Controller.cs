using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Models;
namespace WebApp_Exercise.Controllers;

[Route("Exercise09")]
public class Ex09Controller : Controller
{
    [HttpGet("Enter")]
    public ActionResult Enter()
    {
        var form = new Exercise07Form();
        return View("Enter", form);
    }

    [HttpPost("Result")]
    public IActionResult Result(Exercise07Form form)
    {
        form.Answer = form.Value1 + form.Value2;
        return View("Result", form);
    }

    [HttpGet("Back")]
    public IActionResult Back()
    {
        var form = new Exercise07Form();
        return View("Enter", form);
    }
}