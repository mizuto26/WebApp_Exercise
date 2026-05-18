using Microsoft.EntityFrameworkCore;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Applications.Services;
using WebApp_Exercise.Applications.Services.Impls;
using WebApp_Exercise.Infrastructures.Adapters;
using WebApp_Exercise.Infrastructures.Context;
using WebApp_Exercise.Infrastructures.Repositories;
using WebApp_Exercise.Presentations.Controllers;
using WebApp_Exercise.Presentations.ViewModels;
namespace WebApp_Exercise.Presentations.Extensions;

public static class DependencyExtension
{

    public static void SettingDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        SettingEntityFrameworkCore(configuration, services);
        SettingInfrastructures(services);
        SettingApplications(services);
        SettingPresentations(services);
    }

    private static void SettingEntityFrameworkCore(IConfiguration configuration, IServiceCollection services)
    {
        var connectionString = configuration.GetConnectionString("PostgreSqlConnection");
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
    }

    private static void SettingInfrastructures(IServiceCollection services)
    {
        // ドメインモデル:商品カテゴリと商品カテゴリエンティティの相互変換インターフェイスの実装
        services.AddScoped<ItemCategoryEntityAdapter>();
        // ドメインモデル:商品と商品エンティティの相互変換インターフェイスの実装
        services.AddScoped<ItemEntityAdapter>();
        // ドメインモデル:商品在庫と商品在庫エンティティの相互変換インターフェイスの実装
        services.AddScoped<ItemStockEntityAdapter>();
        // ドメインオブジェクト:商品カテゴリのCRUD操作インターフェイス実装
        services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
        // ドメインオブジェクト:商品のCRUD操作インターフェイスの実装
        services.AddScoped<IItemRepository, ItemRepository>();
    }

    private static void SettingApplications(IServiceCollection services)
    {
        // 商品登録サービスインターフェイスの実装
        services.AddScoped<IItemRegisterService, ItemRegisterService>();
    }

    private static void SettingPresentations(IServiceCollection services)
    {
        // 商品登録ViewModelをドメインオブジェクト:商品に変換するアダプターインターフェイスの実装
        services.AddScoped<ItemRegisterViewModelAdapter>();
        // TempDataへのItemRegisterViewの保存・復元するためのクラス
        // コンストラクタを利用して明示的にDIコンテナにインスタンスを登録する
        services.AddScoped(_ => new TempDataStore<ItemRegisterViewModel>("ItemRegisterViewModel"));
    }
}
