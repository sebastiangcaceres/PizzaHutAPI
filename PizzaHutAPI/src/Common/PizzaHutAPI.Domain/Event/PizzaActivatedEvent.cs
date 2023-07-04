using PizzaHutAPI.Domain.Common;
using PizzaHutAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHutAPI.Domain.Event
{
    public class PizzaActivatedEvent : DomainEvent
    {
        public PizzaActivatedEvent(Pizza pizza)
        {
            Pizza = pizza;
        }

        public Pizza Pizza { get; }
    }
}
