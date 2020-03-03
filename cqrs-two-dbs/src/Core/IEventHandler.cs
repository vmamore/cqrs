using MediatR;

namespace CQRS
{
    public interface IEventHandler<T> : INotificationHandler<T> where T : IEvent
    {
    }
}
