namespace WebApp_Exercise.Exceptions;

/// <summary>
/// DB操作など、アプリ内部の処理に失敗したことを表す例外です。
/// RepositoryやAdapterで低レベルの例外を包むために使います。
/// </summary>
public class InternalException : Exception
{
    public InternalException(string message) : base(message) { }
    public InternalException(string message, Exception innerException) : base(message, innerException) { }
}
