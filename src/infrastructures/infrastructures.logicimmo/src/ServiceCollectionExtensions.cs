using System.Reflection;
using application.tenancy;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructures.logicimmo.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLogicimmoInfrastructure(this IServiceCollection services)
        {
            services.AddLogicimmoValueService().AddLogicimmoSourceService();
            return services;
        }
        public static IServiceCollection AddLogicimmoValueService(this IServiceCollection services)
        {
            services.AddTransient<IValueService, LogicimmoValueServiceAdapter>();
            return services;
        }

        public static IServiceCollection AddLogicimmoSourceService(this IServiceCollection services)
        {
            services.AddTransient<ISourceService, LogicimmoSourceServiceAdapter>();
            return services;
        }
    }
}
