using application.tenancy;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructures.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddTransient(typeof(IInfrastructureProvider<>), typeof(HttpContextInfrastructureProvider<>));
            return services;
        }
    }
}
