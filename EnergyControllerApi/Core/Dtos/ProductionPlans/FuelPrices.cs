using System.Text.Json.Serialization;

namespace EnergyControllerApi.Core.ProductionPlans
{
    public class FuelPrices {
        [JsonPropertyName("Gas(euro/MWh)")]
        public decimal Gas { get; set; } = 13.4M;
        [JsonPropertyName("Kerosine(euro/MWh)")]
        public decimal Kerosine { get; set; } = 50.8M;

        [JsonPropertyName("Kerosine(euro/ton)")]
        public decimal CO2 { get; set; } = 20M;

        [JsonPropertyName("Wind(%)")]
        public decimal Wind { get; set; } = 60;
    }
}