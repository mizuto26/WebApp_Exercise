WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// ==========================
// 1. サービス登録（DI設定）
// ==========================

// MVCを使うための設定
// Controller + View を使えるようにする
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


// ==========================
// 2. アプリ本体を作成
// ==========================

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
}


// ==========================
// 4. Middleware設定
// ==========================

// HTTPで来たアクセスをHTTPSへ転送
app.UseHttpsRedirection();

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
    //idは引数の値
    pattern: "{controller=Home}/{action=Index}/{id?}");


// ==========================
// 6. アプリ起動
// ==========================

app.Run();