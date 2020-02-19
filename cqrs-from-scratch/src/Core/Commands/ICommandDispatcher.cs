using System.Threading.Tasks;

namespace Core.Commands
{
    // Entender pra que serve o dispatcher
    public interface ICommandDispatcher
    {
        Task<bool> ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
