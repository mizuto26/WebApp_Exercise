using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
namespace WebApp_Exercise.Presentations.Controllers;

public class TempDataStore<T>(string key)
    //Tは参照型のみ
    where T : class
{
    private readonly string _key = key;

    public T? Load(Controller controller)
    {
        bool exists = controller.TempData.TryGetValue(_key, out object? value);
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