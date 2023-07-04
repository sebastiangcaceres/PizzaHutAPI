using PizzaHutAPI.Domain.Common;
using PizzaHutAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHutAPI.Domain.Event
{
    public class ClientActivatedEvent : DomainEvent
    {
        public ClientActivatedEvent(Client client)
        {
            Client = client;
        }

        public Client Client { get; }
    }
}
