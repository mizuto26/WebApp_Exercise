namespace WebApp_Exercise.Applications.Adapters;

public interface IRestorer<TTarget, TDomain>
{
    TDomain Restore(TTarget target);
}