using EnergyControllerApi.Core.DataReferenceClasses;

namespace EnergyControllerApi.Core.Domain
{
    public class Windturbine : Powersource
    {
        protected decimal Wind { get; set; }
        public Windturbine(string name, decimal pMin, decimal pMax, decimal wind)
            : base(PowersourceType.Windturbine, name, pMin, pMax) 
            => Wind = wind;

        public override decimal CalculatePower(decimal desiredPower) 
            => base.CalculatePower(desiredPower) / 100 * Wind;
    }
}
