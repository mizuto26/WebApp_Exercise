using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Applications.Services;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Presentations.ViewModels;
namespace WebApp_Exercise.Presentations.Controllers;

/// <summary>
/// 商品登録機能の画面遷移を担当するControllerです。
/// 入力、確認、戻る、登録、完了の各リクエストを受け付けます。
/// </summary>
[Route("ItemRegister")]
public class ItemRegisterController(
    ILogger<ItemRegisterController> logger,
    IItemRegisterService service,
    ItemRegisterViewModelAdapter adapter,
    TempDataStore<ItemRegisterViewModel> tempDataStore)
: Controller
{
    private readonly ILogger<ItemRegisterController> _logger = logger;
    private readonly IItemRegisterService _service = service;
    private readonly ItemRegisterViewModelAdapter _adapter = adapter;
    private readonly TempDataStore<ItemRegisterViewModel> _tempDataStore = tempDataStore;

    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        ItemRegisterViewModel? viewModel = _tempDataStore.Load(this);
        viewModel ??= new ItemRegisterViewModel();
        this.PopulateCategories(viewModel);
        return View("Enter", viewModel);
    }

    private void PopulateCategories(ItemRegisterViewModel viewModel)
    {
        var categories = _service.GetItemCategories();
        viewModel.SetCategories(categories);
        _logger.LogInformation("商品カテゴリリストを設定");
    }

    [HttpPost("Confirm")]
    public IActionResult Confirm(ItemRegisterViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            this.PopulateCategories(viewModel);
            return View("Enter", viewModel);
        }

        string? name = viewModel.Name?.Trim() ?? string.Empty;

        try
        {
            _service.Exists(name);
        }
        catch (ExistsException exception)
        {
            this.ModelState.AddModelError(nameof(viewModel.Name), exception.Message);
            this.PopulateCategories(viewModel);
            return View("Enter", viewModel);
        }

        try
        {
            int categoryId = viewModel.CategoryId ?? 0;
            var itemCategory = _service.GetItemCategoryById(categoryId);
            _logger.LogInformation("商品カテゴリId:{CategoryId}の商品カテゴリを取得する", categoryId);
            viewModel.CategoryName = itemCategory.Name;
        }
        catch (NotFoundException exception)
        {
            this.ModelState.AddModelError(nameof(viewModel.CategoryId), exception.Message);
            this.PopulateCategories(viewModel);
            return View("Enter", viewModel);
        }
        return View("Confirm", viewModel);
    }

    [HttpPost("Back")]
    public IActionResult Back(ItemRegisterViewModel viewModel)
    {
        _logger.LogInformation("[戻る]ボタンクリック:{ViewModel}", viewModel!.ToString());
        _tempDataStore.Save(this, viewModel);
        return RedirectToAction("Enter");
    }

    [HttpPost("Register")]
    public IActionResult Register(ItemRegisterViewModel viewModel)
    {
        _tempDataStore.Save(this, viewModel);
        return RedirectToAction("Complete");
    }

    [HttpGet("Complete")]
    public IActionResult Complete()
    {
        ItemRegisterViewModel? viewModel = _tempDataStore.Load(this);
        if (viewModel == null) return RedirectToAction("Enter");

        _logger.LogInformation("商品登録処理を開始");

        var item = _adapter.Restore(viewModel!);
        _service.Register(item);
        return View("Complete", viewModel);
    }
}
