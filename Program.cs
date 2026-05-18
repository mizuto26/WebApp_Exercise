using WebApp_Exercise.Presentations.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();

DependencyExtension.SettingDependencyInjection(builder.Services, builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();