using application.tenancy;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructures.common.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services)
        {
            services.AddCommonValueService().AddCommonSourceService();
            return services;
        }

        public static IServiceCollection AddCommonValueService(this IServiceCollection services)
        {
            services.AddTransient<IValueService, CommonValueServiceAdapter>();
            return services;
        }

        public static IServiceCollection AddCommonSourceService(this IServiceCollection services)
        {
            services.AddTransient<ISourceService, CommonSourceServiceAdapter>();
            return services;
        }
    }
}
