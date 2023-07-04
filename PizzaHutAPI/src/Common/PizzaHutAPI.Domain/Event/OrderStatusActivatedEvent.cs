using PizzaHutAPI.Domain.Common;
using PizzaHutAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHutAPI.Domain.Event
{
    public class OrderStatusActivatedEvent : DomainEvent
    {
        public OrderStatusActivatedEvent(OrderStatus orderStatus)
        {
            OrderStatus = orderStatus;
        }

        public OrderStatus OrderStatus { get; }
    }
}
