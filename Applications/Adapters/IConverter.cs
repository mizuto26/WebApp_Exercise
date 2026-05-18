namespace WebApp_Exercise.Applications.Adapters;

/// <summary>
/// ドメインモデルを別の形式へ変換するAdapterの共通Interfaceです。
/// 主にDomainからEntityやViewModelへ変換するときに使います。
/// </summary>
public interface IConverter<TDomain, TTarget>
{
    TTarget Convert(TDomain domain);
}
