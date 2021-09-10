using application.tenancy;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructures.seloger.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddSelogerInfrastructure(this IServiceCollection services)
        {
            services.AddSelogerValueService().AddSelogerSourceService();
            return services;
        }

        public static IServiceCollection AddSelogerValueService(this IServiceCollection services)
        {
            services.AddTransient<IValueService, SelogerValueServiceAdapter>();

            return services;
        }

        public static IServiceCollection AddSelogerSourceService(this IServiceCollection services)
        {
            services.AddTransient<ISourceService, SelogerSourceServiceAdapter>();

            return services;
        }
    }
}
