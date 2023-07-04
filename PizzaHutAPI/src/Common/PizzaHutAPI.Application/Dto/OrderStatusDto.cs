using Mapster;
using PizzaHutAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Dto
{
    public class OrderStatusDto : IRegister
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<OrderStatus, OrderStatusDto>();
            //.Map(dest => dest.CreateDate,
            //    src => $"{src.CreateDate.ToShortDateString()}");
        }
    }
}
