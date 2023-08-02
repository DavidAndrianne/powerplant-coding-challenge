using EnergyControllerApi.Core.Commands;
using EnergyControllerApi.Core.ProductionPlans;
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
        public IEnumerable<PowerPlantProductionPlan> Post(CalculateProductionPlanCommand command)
        {
            _logger.LogInformation($"Calculating plan for {command.Load} load");
            return Enumerable.Range(1, 5)
                .Select(index => new PowerPlantProductionPlan($"plant{index}", Random.Shared.Next(0, (int)command.Load)))
                .ToArray();
        }
    }
}