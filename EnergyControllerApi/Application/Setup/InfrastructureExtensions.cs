using EnergyControllerApi.Infrastructure;

namespace EnergyControllerApi.Application.Setup
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<PowerPlanService>();
            return services;
        }
    }
}
