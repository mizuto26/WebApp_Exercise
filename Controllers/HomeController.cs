using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Models;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace WebApp_Exercise.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    //クラス専用ログ出力機
    private readonly ILogger<HomeController> _logger = logger;

    //ActionResultはControllerが返す結果の型
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var viewModel = new ErrorViewModel
        {
            //エラー追跡IDの作成
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };

        return View(viewModel);
    }

    public IActionResult ViewContent()
    {
        return Content("テキスト文字列");
    }

    //static変数　全部のUnicode文字を許可する設定
    private static readonly JsonSerializerOptions JsonOptions =
            new()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = false
            };

    public IActionResult ViewJson()
    {
        var product = new
        {
            Id = 1,
            Name = "ノートPC"
        };

        string json = JsonSerializer.Serialize(product, JsonOptions);
        return Content(json, "application/json");
    }
}
