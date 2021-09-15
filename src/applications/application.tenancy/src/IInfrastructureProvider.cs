namespace application.tenancy
{
    public interface IInfrastructureProvider<TService>
    {
        TService GetService();
    }
}
