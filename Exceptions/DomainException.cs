namespace WebApp_Exercise.Exceptions;

/// <summary>
/// ドメインモデルの業務ルール違反を表す例外です。
/// 例: 商品名が空、価格や在庫数が不正な場合に使います。
/// </summary>
public class DomainException : Exception
{
    public DomainException(string message) : base(message) { }
    public DomainException(string message, Exception innerException) : base(message, innerException) { }
}
