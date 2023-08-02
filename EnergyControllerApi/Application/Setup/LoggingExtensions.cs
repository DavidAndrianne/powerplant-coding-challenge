using Serilog;

namespace EnergyControllerApi.Application.Setup
{
    public static class LoggingExtensions
    {
        public static void AddSeriLogging(this IServiceCollection services)
        {
            var serilog = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();
            var loggerFactory = new LoggerFactory()
                .AddSerilog(serilog);

            services.AddSingleton(loggerFactory);
        }
    }
}
