using EnergyControllerApi.Core.DataReferenceClasses;

namespace EnergyControllerApi.Core.Domain
{
    public class Powersource
    {
        public virtual string Name { get; set; }
        public virtual PowersourceType Type { get; protected set; }
        public virtual decimal PMin { get; protected set; }
        public virtual decimal PMax { get; protected set; }
        public virtual decimal Efficiency { get; protected set; }
        public virtual decimal Fuelprice { get; protected set; }

        public Powersource(PowersourceType type, string name, decimal pMin, decimal pMax, decimal efficiency = 1, decimal fuelprice = 0)
        {
            Name = name;
            Type = type;
            PMin = pMin;
            PMax = pMax;
            Efficiency = efficiency;
            Fuelprice = fuelprice;
        }

        public virtual decimal CalculatePower(decimal desiredLoad)
        {
            var power = desiredLoad / Efficiency;
            if (power < PMin) return PMin;
            if (power > PMax) return PMax;
            return power;
        }

        public virtual decimal CalculateOffloadInMw(decimal power)
        {
            return power * Efficiency;
        }
    }
}
