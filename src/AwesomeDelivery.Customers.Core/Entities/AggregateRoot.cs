using AwesomeDelivery.Customers.Core.Events;

namespace AwesomeDelivery.Customers.Core.Entities
{
    public abstract class AggregateRoot : IEntity
    {
        public AggregateRoot()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
        
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent @event) {
            _events.Add(@event);
        }
    }
}