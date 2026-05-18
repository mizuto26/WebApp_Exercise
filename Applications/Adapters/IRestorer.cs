namespace WebApp_Exercise.Applications.Adapters;

/// <summary>
/// 別の形式のデータからドメインモデルを復元するAdapterの共通Interfaceです。
/// 主にEntityやViewModelからDomainへ戻すときに使います。
/// </summary>
public interface IRestorer<TTarget, TDomain>
{
    TDomain Restore(TTarget target);
}
