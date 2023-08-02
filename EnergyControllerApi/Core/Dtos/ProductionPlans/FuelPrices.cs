namespace EnergyControllerApi.Core.ProductionPlans
{
    public class FuelPrices {
        // (euro/MWh)
        public decimal Gas { get; set; } = 13.4M;
        // (euro/MWh)
        public decimal Kerosine { get; set; } = 50.8M;
        // (euro/ton)
        public decimal CO2 { get; set; } = 20M;
        // (%)
        public decimal Wind { get; set; } = 60;
    }
}