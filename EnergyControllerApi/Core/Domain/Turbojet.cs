using EnergyControllerApi.Core.DataReferenceClasses;

namespace EnergyControllerApi.Core.Domain
{
    public class Turbojet : Powersource
    {
        public Turbojet(string name, decimal pMin, decimal pMax, decimal efficiency, decimal kerosinePrice)
            : base(PowersourceType.Turbojet, name, pMin, pMax, efficiency, kerosinePrice)
        {
        }
    }
}
