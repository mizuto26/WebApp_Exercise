using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Models;
namespace WebApp_Exercise.Controllers;

[Route("FormSample")]
public class TagHelperFormController : Controller
{
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        SampleForm? form = new();
        return View(viewName: "Enter", model: form);
    }

    [ValidateAntiForgeryToken]
    [HttpPost("Result")]
    public IActionResult Result(SampleForm form)
    {
        return View(viewName: "Result", model: form);
    }

    [HttpGet("Back")]
    public IActionResult Back(SampleForm form)
    {
        return View(viewName: "Enter", model: form);
    }
}