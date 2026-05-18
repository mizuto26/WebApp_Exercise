namespace WebApp_Exercise.Applications.Adapters;

public interface IConverter<TDomain, TTarget>
{
    TTarget Convert(TDomain domain);
}