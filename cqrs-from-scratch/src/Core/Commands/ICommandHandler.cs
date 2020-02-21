using CQRS.Dominio;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    // Entender o in
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task<Resultado> ExecuteAsync(TCommand command);
    }
}
