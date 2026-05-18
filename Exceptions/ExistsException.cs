namespace WebApp_Exercise.Exceptions;

/// <summary>
/// 登録しようとしたデータがすでに存在することを表す例外です。
/// 例: 同じ商品名が既に登録済みの場合に使います。
/// </summary>
public class ExistsException : Exception
{
    public ExistsException(string message) : base(message) { }
    public ExistsException(string message, Exception innerException) : base(message, innerException) { }
}
