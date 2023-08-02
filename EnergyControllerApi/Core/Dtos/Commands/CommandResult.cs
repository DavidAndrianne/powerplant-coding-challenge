namespace EnergyControllerApi.Core.Dtos.Commands
{
    public class CommandResult<T>
    {
        public T Result { get; set; }
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();

        public static CommandResult<T> Success(T result) => new CommandResult<T> { Result = result };
        public static CommandResult<T> Error(IEnumerable<String> errors) => new CommandResult<T> { Errors = errors };
    }
}
