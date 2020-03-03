using CQRS.Dominio;
using MediatR;

namespace CQRS
{
    public interface ICommandHandler<T> : IRequestHandler<T, Resultado> where T : ICommand
    {
    }
}
