using EnergyControllerApi.Core.Dtos.Commands;

namespace EnergyControllerApi.Integration
{
    public interface ICommandHandler<in TArgs, TResult>
    {
        CommandResult<TResult> Execute(TArgs command);
    }
}
