using CQRS.Dominio;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    // Entender pra que serve o dispatcher
    public interface ICommandDispatcher
    {
        Task<Resultado> ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
