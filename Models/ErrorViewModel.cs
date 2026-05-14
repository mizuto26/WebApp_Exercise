namespace WebApp_Exercise.Models;

public class ErrorViewModel
{
    // エラー追跡ID
    public string? RequestId { get; set; }

    // RequestIdが存在するかどうか
    public bool ShowRequestId
    {
        get
        {
            return !string.IsNullOrEmpty(RequestId);
        }
    }
}