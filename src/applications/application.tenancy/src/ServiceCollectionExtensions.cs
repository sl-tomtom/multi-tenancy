using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace application.tenancy.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTenantApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }
}
