using EnergyControllerApi.Core.Commands;
using EnergyControllerApi.Core.ProductionPlans;

namespace EnergyControllerApi.Integration.CommandHandlers
{
    public class CalculateProductionPlanCommandHandler : ICommandHandler<CalculateProductionPlanCommand, IEnumerable<PowerPlantProductionPlan>>
    {
        public IEnumerable<PowerPlantProductionPlan> Execute(CalculateProductionPlanCommand command)
        {
            return Enumerable.Range(1, 5)
                .Select(index => new PowerPlantProductionPlan($"plant{index}", Random.Shared.Next(0, (int)command.Load)))
                .ToArray();
        }
    }
}
