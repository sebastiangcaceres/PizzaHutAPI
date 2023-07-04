using PizzaHutAPI.Domain.Common;
using PizzaHutAPI.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHutAPI.Domain.Entities
{
    public class OrderStatus : AuditableEntity, IHasDomainEvent
    {
        public OrderStatus()
        {
            DomainEvents = new List<DomainEvent>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        private bool _active;
        public bool Active
        {
            get => _active;
            set
            {
                if (value && _active == false)
                {
                    DomainEvents.Add(new OrderStatusActivatedEvent(this));
                }

                _active = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; }
    }
}
