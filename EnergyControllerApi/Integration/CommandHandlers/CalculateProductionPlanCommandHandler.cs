using EnergyControllerApi.Core.Commands;
using EnergyControllerApi.Core.DataReferenceClasses;
using EnergyControllerApi.Core.Dtos.Commands;
using EnergyControllerApi.Core.ProductionPlans;
using EnergyControllerApi.Infrastructure;
using System.Text.Json;

namespace EnergyControllerApi.Integration.CommandHandlers
{
    public class CalculateProductionPlanCommandHandler : ICommandHandler<CalculateProductionPlanCommand, IEnumerable<PowerPlantProductionPlan>>
    {
        public PowerPlanService PowerPlanService { get; set; }
        public CalculateProductionPlanCommandHandler(PowerPlanService powerPlanService) => PowerPlanService = powerPlanService;

        public CommandResult<IEnumerable<PowerPlantProductionPlan>> Execute(CalculateProductionPlanCommand command)
        {
            var errors = Validate(command);
            if (errors.Any()) return CommandResult<IEnumerable<PowerPlantProductionPlan>>.Error(errors);

            var powerPlans = PowerPlanService.AssignPowerForLoad(command.Load, command.Fuels, command.PowerPlants);
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
