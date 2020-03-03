using CQRS.Dominio;
using MediatR;

namespace CQRS
{
    public interface ICommand : IRequest<Resultado>
    {
    }
}
