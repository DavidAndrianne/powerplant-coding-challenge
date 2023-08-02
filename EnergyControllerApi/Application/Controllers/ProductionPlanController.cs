using EnergyControllerApi.Application.Controllers;
using EnergyControllerApi.Core.Commands;
using EnergyControllerApi.Core.ProductionPlans;
using EnergyControllerApi.Integration;
using Microsoft.AspNetCore.Mvc;

namespace EnergyControllerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : EnergyBaseController<ProductionPlanController>
    {
        public ProductionPlanController(ILogger<ProductionPlanController> logger) : base(logger) { }

        [HttpPost]
        public ActionResult<IEnumerable<PowerPlantProductionPlan>> Post(
            CalculateProductionPlanCommand command, 
            [FromServices] ICommandHandler<CalculateProductionPlanCommand, IEnumerable<PowerPlantProductionPlan>> commandHandler
            )
        {
            _logger.LogInformation($"Calculating plan for {command.Load} load");
            var result = commandHandler.Execute(command);
            if (result.Errors.Any()) return ReturnErrors(result);
            return Ok(result.Result);
        }
    }
}