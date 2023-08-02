using EnergyControllerApi.Core.Commands;
using EnergyControllerApi.Core.ProductionPlans;
using EnergyControllerApi.Integration;
using Microsoft.AspNetCore.Mvc;

namespace EnergyControllerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        private readonly ILogger<ProductionPlanController> _logger;

        public ProductionPlanController(ILogger<ProductionPlanController> logger) => _logger = logger;

        [HttpPost]
        public IEnumerable<PowerPlantProductionPlan> Post(
            CalculateProductionPlanCommand command, 
            [FromServices] ICommandHandler<CalculateProductionPlanCommand, IEnumerable<PowerPlantProductionPlan>> commandHandler
            )
        {
            _logger.LogInformation($"Calculating plan for {command.Load} load");
            return commandHandler.Execute(command);
        }
    }
}