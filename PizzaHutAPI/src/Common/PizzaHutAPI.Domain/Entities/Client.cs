using PizzaHutAPI.Domain.Common;
using PizzaHutAPI.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHutAPI.Domain.Entities
{
    public class Client : AuditableEntity, IHasDomainEvent
    {
        public Client()
        {
            DomainEvents = new List<DomainEvent>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<DeliveryAddress> DeliveryAddresses { get; set; }

        private bool _active;
        public bool Active
        {
            get => _active;
            set
            {
                if (value && _active == false)
                {
                    DomainEvents.Add(new ClientActivatedEvent(this));
                }

                _active = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; }
    }
}
