using Mapster;
using PizzaHutAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Dto
{
    public class OrderDto : IRegister
    {
        public OrderDto()
        {
            Pizzas = new List<PizzaDto>();
        }
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int DeliveryAddressId { get; set; }
        public DeliveryAddressDto DeliveryAddress { get; set; }
        public IList<PizzaDto> Pizzas { get; set; }
        public decimal OrderCost { get; set; }
        public OrderStatusDto Status { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public string Comment { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Order, OrderDto>();
            //.Map(dest => dest.CreateDate,
            //    src => $"{src.CreateDate.ToShortDateString()}");
        }
    }
}
