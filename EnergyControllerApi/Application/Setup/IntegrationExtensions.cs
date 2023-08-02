using EnergyControllerApi.Core.Commands;
using EnergyControllerApi.Core.ProductionPlans;
using EnergyControllerApi.Integration;
using EnergyControllerApi.Integration.CommandHandlers;

namespace EnergyControllerApi.Application.Setup
{
    public static class IntegrationExtensions
    {
        public static IServiceCollection AddIntegration(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<CalculateProductionPlanCommand, IEnumerable<PowerPlantProductionPlan>>, CalculateProductionPlanCommandHandler>();
            return services;
        }
    }
}
