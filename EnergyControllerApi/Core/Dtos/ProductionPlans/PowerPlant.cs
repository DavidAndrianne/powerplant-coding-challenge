namespace EnergyControllerApi.Core.ProductionPlans
{
    public class PowerPlant {
        public string Name { get; set; } = "Gas fired 1";
        public string Type { get; set; } = "gasfired";
        public decimal Efficiency { get; set; } = 0.55M;
        public int PMin { get; set; } = 100;
        public int PMax { get; set; } = 460;
    }
}