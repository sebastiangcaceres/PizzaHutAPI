﻿using PizzaHutAPI.Domain.Common;
using PizzaHutAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHutAPI.Domain.Event
{
    public class OrderCreatedEvent : DomainEvent
    {
        public OrderCreatedEvent(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}
