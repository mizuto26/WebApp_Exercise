using WebApp_Exercise.Presentations.Extensions;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.SettingDependencyInjection(builder.Configuration);

WebApplication? app = builder.Build();
// ==========================
// 3. エラー・セキュリティ設定
// ==========================

// 本番環境のときだけ使う設定
if (!app.Environment.IsDevelopment())
{
    // エラーが発生したら /Home/Error に飛ばす
    app.UseExceptionHandler("/Home/Error");

    // HTTPSを強制する設定
    app.UseHsts();

    // HTTPで来たアクセスをHTTPSへ転送
    app.UseHttpsRedirection();
}


// ==========================
// 4. Middleware設定
// ==========================

// wwwroot内のCSS・JS・画像を使えるようにする
app.UseStaticFiles();

// URLをController/Actionに振り分ける準備
app.UseRouting();

// 認可チェック
app.UseAuthorization();


// ==========================
// 5. ルーティング設定
// ==========================

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
