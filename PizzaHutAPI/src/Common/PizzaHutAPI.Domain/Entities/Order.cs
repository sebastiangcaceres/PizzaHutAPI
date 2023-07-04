using PizzaHutAPI.Domain.Common;
using PizzaHutAPI.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHutAPI.Domain.Entities
{
    public class Order : AuditableEntity, IHasDomainEvent
    {
        public Order()
        {
            DomainEvents = new List<DomainEvent>();
        }
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int DeliveryAddressId { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public decimal OrderCost { get; set; }
        public OrderStatus Status { get; set; }

        public int OrderStatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public string Comment { get; set; }

        private bool _active;
        public bool Active
        {
            get => _active;
            set
            {
                if (value && _active == false)
                {
                    DomainEvents.Add(new OrderActivatedEvent(this));
                }

                _active = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; }
    }
}
