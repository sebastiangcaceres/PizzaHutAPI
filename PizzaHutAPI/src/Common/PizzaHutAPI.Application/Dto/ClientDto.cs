using Mapster;
using PizzaHutAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Dto
{
    public class ClientDto : IRegister
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<DeliveryAddressDto> DeliveryAddresses { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Client, ClientDto>();
            //.Map(dest => dest.CreateDate,
            //    src => $"{src.CreateDate.ToShortDateString()}");
        }
    }
}
