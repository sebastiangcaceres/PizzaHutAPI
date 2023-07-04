using PizzaHutAPI.Domain.Common;
using PizzaHutAPI.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHutAPI.Domain.Entities
{
    public class DeliveryAddress : AuditableEntity, IHasDomainEvent
    {
        public DeliveryAddress()
        {
            DomainEvents = new List<DomainEvent>();
        }

        public int Id { get; set; }
        public string Address { get; set; }

        private bool _active;
        public bool Active
        {
            get => _active;
            set
            {
                if (value && _active == false)
                {
                    DomainEvents.Add(new DeliveryAddressActivatedEvent(this));
                }

                _active = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; }
    }
}
