namespace EnergyControllerApi.Integration
{
    public interface ICommandHandler<in TArgs, out TResult>
    {
        TResult Execute(TArgs command);
    }
}
