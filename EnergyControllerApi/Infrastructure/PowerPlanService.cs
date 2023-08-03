using EnergyControllerApi.Core.Domain;
using EnergyControllerApi.Core.ProductionPlans;
using EnergyControllerApi.Core.Util;

namespace EnergyControllerApi.Infrastructure
{
    public class PowerPlanService
    {
        public IEnumerable<PowerPlantProductionPlan> AssignPowerForLoad(decimal load, FuelPrices fuels, List<PowerPlant> powerPlants)
        {
            var sources = PowersourceFactory.ToPowerSources(powerPlants, fuels);
            var orderedSources = SortMeritOrder(sources);

            var remainingLoad = load;
            return orderedSources
               .Select(p => {
                   var plantPower = p.CalculatePower(remainingLoad);
                   remainingLoad -= plantPower;
                   return new PowerPlantProductionPlan(p.Name, plantPower);
                   })
               .ToArray();
        }

        private IEnumerable<Powersource> SortMeritOrder(IEnumerable<Powersource> sources) 
            => sources.OrderBy(x => x.Fuelprice * (1-x.Efficiency));
    }
}
