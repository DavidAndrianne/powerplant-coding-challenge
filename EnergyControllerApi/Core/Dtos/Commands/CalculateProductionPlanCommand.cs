using EnergyControllerApi.Core.ProductionPlans;

namespace EnergyControllerApi.Core.Commands
{
    public class CalculateProductionPlanCommand
    {
        public decimal Load { get; set; } = 100;

        public FuelPrices Fuels { get; set; } = new FuelPrices();

        public List<PowerPlant> PowerPlants { get; set; } = new List<PowerPlant> { new PowerPlant() };
    }
}