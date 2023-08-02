namespace EnergyControllerApi.Core.DataReferenceClasses
{
    public class PowersourceType
    {
        public static PowersourceType GasFired { get; set; } = new PowersourceType(nameof(GasFired));
        public static PowersourceType Turbojet { get; set; } = new PowersourceType(nameof(Turbojet));
        public static PowersourceType Windturbine { get; set; } = new PowersourceType(nameof(Windturbine));

        public static IEnumerable<PowersourceType> All = new List<PowersourceType>() { GasFired, Turbojet, Windturbine };

        public string Name { get; private set; }

        private PowersourceType(string name) => Name = name;

        public static bool TryParse(string name, out PowersourceType powersourceType)
        {
            var result = All.SingleOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            powersourceType = result;
            return result != null;
        }
    }
}
