using EnergyControllerApi.Core.DataReferenceClasses;
using EnergyControllerApi.Core.Domain;
using EnergyControllerApi.Core.ProductionPlans;

namespace EnergyControllerApi.Core.Util
{
    public static class PowersourceFactory
    {
        private static readonly Dictionary<PowersourceType, Func<PowerPlant, FuelPrices, Powersource>> Strategies
            = new Dictionary<PowersourceType, Func<PowerPlant, FuelPrices, Powersource>>()
            {
                { PowersourceType.GasFired, (plant, fuels) => new GasFired(plant.Name, plant.PMin, plant.PMax, plant.Efficiency, fuels.Gas) },
                { PowersourceType.Turbojet, (plant, fuels) => new Turbojet(plant.Name, plant.PMin, plant.PMax, plant.Efficiency, fuels.Kerosine) },
                { PowersourceType.Windturbine, (plant, fuels) => new Windturbine(plant.Name, plant.PMin, plant.PMax, fuels.Wind) },
            };
        public static IEnumerable<Powersource> ToPowerSources(this IEnumerable<PowerPlant> powerplants, FuelPrices fuels)
        {
            return powerplants.Select(plant => MapToPowersource(plant, fuels))
            .ToList();
        }

        private static Powersource MapToPowersource(PowerPlant plant, FuelPrices fuels)
        {
            if (!PowersourceType.TryParse(plant.Type, out var type)) throw new ApplicationException($"{nameof(PowersourceFactory)}:Could not identify powersourcetype '${plant.Type}'");
            if (!Strategies.ContainsKey(type)) throw new ApplicationException($"{nameof(PowersourceFactory)}: Missing strategy for '{type.Name}'");
            return Strategies[type](plant, fuels);
        }
    }
}
