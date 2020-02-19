using System.Threading.Tasks;

namespace Core.Commands
{
    // Entender o in
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task<bool> ExecuteAsync(TCommand command);
    }
}
