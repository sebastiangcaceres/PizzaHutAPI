using PizzaHutAPI.Domain.Common;
using PizzaHutAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHutAPI.Domain.Event
{
    public class ClientCreatedEvent : DomainEvent
    {
        public ClientCreatedEvent(Client client)
        {
            Client = client;
        }

        public Client Client { get; }
    }
}
