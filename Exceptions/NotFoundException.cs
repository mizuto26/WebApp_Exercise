namespace WebApp_Exercise.Exceptions;

/// <summary>
/// 指定されたデータが見つからなかったことを表す例外です。
/// 例: 指定された商品カテゴリIDが存在しない場合に使います。
/// </summary>
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
