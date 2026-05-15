using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Models;
namespace WebApp_Exercise.Controllers;

[Route("Exercise09")]
public class Ex09Controller : Controller
{
    [HttpGet("Enter")]
    public ActionResult Enter()
    {
        Exercise07Form? form = new();
        return View("Enter", form);
    }

    [HttpPost("Calc")]
    public IActionResult Calc(Exercise07Form form)
    {
        if (!this.ModelState.IsValid)
        {
            return View("Enter", form);
        }
        string? json = JsonSerializer.Serialize(form);
        this.TempData["Exercise07Form"] = json;
        return RedirectToAction("Result");
    }

    [HttpGet("Result")]
    public IActionResult Result()
    {
        string? json = (string)TempData["Exercise07Form"]!;
        if (string.IsNullOrEmpty(json))
        {
            return RedirectToAction("Enter");
        }
        Exercise07Form? form = JsonSerializer.Deserialize<Exercise07Form>(json);
        form!.Answer = form.Value1 + form.Value2;
        return View("Result", form);
    }

    [HttpGet("Back")]
    public IActionResult Back()
    {
        return RedirectToAction("Enter");
    }
}

