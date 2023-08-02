using EnergyControllerApi.Controllers;
using EnergyControllerApi.Core.Dtos.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EnergyControllerApi.Application.Controllers
{
    public abstract class EnergyBaseController<TController> : ControllerBase
    {
        protected readonly ILogger<TController> _logger;

        protected EnergyBaseController(ILogger<TController> logger) => _logger = logger;

        protected ActionResult ReturnErrors<T>(CommandResult<T> result)
        {
            _logger.LogError(string.Join(",", result.Errors));
            return BadRequest(result.Errors);
        }
    }
}
