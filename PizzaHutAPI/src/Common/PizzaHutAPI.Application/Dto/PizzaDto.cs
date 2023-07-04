using Mapster;
using PizzaHutAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Dto
{
    public class PizzaDto : IRegister
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Pizza, PizzaDto>();
            //.Map(dest => dest.CreateDate,
            //    src => $"{src.CreateDate.ToShortDateString()}");
        }
    }
}
