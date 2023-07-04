using PizzaHutAPI.Domain.Common;
using PizzaHutAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHutAPI.Domain.Event
{
    public class DeliveryAddressActivatedEvent : DomainEvent
    {
        public DeliveryAddressActivatedEvent(DeliveryAddress deliveryAddress)
        {
            DeliveryAddress = deliveryAddress;
        }

        public DeliveryAddress DeliveryAddress { get; }
    }
}
