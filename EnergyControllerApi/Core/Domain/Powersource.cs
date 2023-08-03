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

        public virtual decimal CalculatePower(decimal desiredPower)
        {
            if (desiredPower == 0) return 0M; // no need for further power
            if (desiredPower < PMin) return PMin; // can't go below minimum power
            if (desiredPower > PMax) return PMax; // can't exceed max power
            return desiredPower;
        }
    }
}
