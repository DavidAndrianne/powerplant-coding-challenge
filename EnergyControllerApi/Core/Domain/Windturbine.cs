using EnergyControllerApi.Core.DataReferenceClasses;

namespace EnergyControllerApi.Core.Domain
{
    public class Windturbine : Powersource
    {
        protected decimal Wind { get; set; }
        public Windturbine(string name, decimal pMin, decimal pMax, decimal wind)
            : base(PowersourceType.Windturbine, name, pMin, pMax)
        {
            Wind = wind;
        }

        public override decimal CalculatePower(decimal desiredLoad)
        {
            var power = desiredLoad / 100 * Wind;
            if (power < PMin) return PMin / 100 * Wind;
            if (power > PMax) return PMax / 100 * Wind;
            return power;
        }
    }
}
