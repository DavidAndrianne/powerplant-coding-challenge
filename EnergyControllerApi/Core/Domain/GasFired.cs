using EnergyControllerApi.Core.DataReferenceClasses;

namespace EnergyControllerApi.Core.Domain
{
    public class GasFired : Powersource
    {
        public GasFired(string name, decimal pMin, decimal pMax, decimal efficiency, decimal gasPrice) 
            : base(PowersourceType.GasFired, name, pMin, pMax, efficiency, gasPrice)
        {
        }
    }
}
