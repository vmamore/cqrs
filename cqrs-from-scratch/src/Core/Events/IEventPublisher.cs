using System.Threading.Tasks;

namespace CQRS.Events
{
    public interface IEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
