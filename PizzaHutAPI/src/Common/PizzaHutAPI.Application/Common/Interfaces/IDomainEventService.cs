﻿using PizzaHutAPI.Domain.Common;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
