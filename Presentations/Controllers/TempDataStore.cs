using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
namespace WebApp_Exercise.Presentations.Controllers;

/// <summary>
/// TempDataにオブジェクトをJSON形式で保存・復元する補助クラスです。
/// 確認画面から完了画面へ入力内容を引き継ぐために使います。
/// </summary>
public class TempDataStore<T>(string key)
    //Tは参照型のみ
    where T : class
{
    private readonly string _key = key;

    public T? Load(Controller controller)
    {
        //out -> 「戻り値を追加で返す」
        bool exists = controller.TempData.TryGetValue(key: _key, value: out object? value);
        if (!exists) return null;

        string? json = value as string;
        if (string.IsNullOrWhiteSpace(json)) return null;

        try
        {
            T? model = JsonSerializer.Deserialize<T>(json);
            return model;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    public void Save(Controller controller, T model)
    {
        string json = JsonSerializer.Serialize(model);
        controller.TempData[_key] = json;
    }
}
