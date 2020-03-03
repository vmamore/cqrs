using MediatR;

namespace CQRS
{
    public interface IQuery<T> : IRequest<T>
    {
    }
}
