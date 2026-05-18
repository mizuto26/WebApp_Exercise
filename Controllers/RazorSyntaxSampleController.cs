using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Models;
namespace WebApp_Exercise.Controllers;

[Route("Razor")]
public class RazorSyntaxSampleController : Controller
{
    [HttpGet("ShowData")]
    public ActionResult Show()
    {
        List<SampleForm> list =
        [
            new() { Name = "山田太郎",      Age = 25 },
            new() { Name = "鈴木花子",      Age = 23 },
            new() { Name = "田中次郎",      Age = 26 },
            new() { Name = "佐藤かおり",    Age = 25 }
        ];
        return View(viewName: "ShowData", model: list);
    }
}