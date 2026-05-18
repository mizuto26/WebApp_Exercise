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

/// <summary>
/// アプリで使うDbContext、Repository、Service、AdapterをDIコンテナへ登録します。
/// Program.csから呼び出され、各層の依存関係(interfaceへの実装クラス)をまとめて設定します。
/// </summary>
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

    //infrasatructure層のRepository,Adapter
    private static void SettingInfrastructures(IServiceCollection services)
    {
        services.AddScoped<ItemCategoryEntityAdapter>();
        services.AddScoped<ItemEntityAdapter>();
        services.AddScoped<ItemStockEntityAdapter>();

        services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
    }

    //Application層のservice(useCase)
    private static void SettingApplications(IServiceCollection services)
    {
        services.AddScoped<IItemRegisterService, ItemRegisterService>();
    }

    //Presentation層のAdapter
    private static void SettingPresentations(IServiceCollection services)
    {
        services.AddScoped<ItemRegisterViewModelAdapter>();
        services.AddScoped(_ => new TempDataStore<ItemRegisterViewModel>("ItemRegisterViewModel"));
    }
}
