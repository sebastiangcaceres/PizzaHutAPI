using PizzaHutAPI.Application.Common.Interfaces;
using System;

namespace PizzaHutAPI.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
