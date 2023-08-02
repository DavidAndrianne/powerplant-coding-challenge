using EnergyControllerApi.Core.Commands;
using EnergyControllerApi.Core.DataReferenceClasses;
using EnergyControllerApi.Core.Dtos.Commands;
using EnergyControllerApi.Core.ProductionPlans;
using System.Text.Json;

namespace EnergyControllerApi.Integration.CommandHandlers
{
    public class CalculateProductionPlanCommandHandler : ICommandHandler<CalculateProductionPlanCommand, IEnumerable<PowerPlantProductionPlan>>
    {
        public CommandResult<IEnumerable<PowerPlantProductionPlan>> Execute(CalculateProductionPlanCommand command)
        {
            var errors = Validate(command);
            if (errors.Any()) return CommandResult<IEnumerable<PowerPlantProductionPlan>>.Error(errors);

            var powerPlans = Enumerable.Range(1, 5)
                .Select(index => new PowerPlantProductionPlan($"plant{index}", Random.Shared.Next(0, (int)command.Load)))
                .ToArray();
            return CommandResult<IEnumerable<PowerPlantProductionPlan>>.Success(powerPlans);
        }

        protected IEnumerable<string> Validate(CalculateProductionPlanCommand command)
        {
            var invalidPowerPlants = command.PowerPlants.Where(x => !PowersourceType.TryParse(x.Type, out var powersourceType))
                .ToList();

            var acceptedValues = JsonSerializer.Serialize(PowersourceType.All.Select(x => x.Name).ToArray());
            return invalidPowerPlants.Select(x => $"'{x.Type}' is an invalid {nameof(PowersourceType)}; accepted values are {acceptedValues}");
        }
    }
}
