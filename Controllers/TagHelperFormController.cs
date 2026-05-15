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
        return View("Enter", form);
    }

    [HttpPost("Result")]
    public IActionResult Result(SampleForm form)
    {
        return View("Result", form);
    }

    [HttpGet("Back")]
    public IActionResult Back(SampleForm form)
    {
        return View("Enter", form);
    }
}