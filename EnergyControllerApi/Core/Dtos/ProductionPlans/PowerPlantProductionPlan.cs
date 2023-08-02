namespace EnergyControllerApi.Core.ProductionPlans
{
    public class PowerPlantProductionPlan
    {
        public string Name { get; set; }
        public decimal P { get; set; }

        public PowerPlantProductionPlan() => Name = "N/A";
        public PowerPlantProductionPlan(string name, decimal p)
        {
            Name = name;
            P = p;
        }
    }
}