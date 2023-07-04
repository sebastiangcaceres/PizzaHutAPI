using MapsterMapper;
using PizzaHutAPI.Application.Common.Interfaces;
using PizzaHutAPI.Application.Common.Models;
using PizzaHutAPI.Application.Dto;
using PizzaHutAPI.Domain.Entities;
using PizzaHutAPI.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Clients.Commands.Create
{
    public record CreateClientCommand : IRequestWrapper<ClientDto>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<DeliveryAddressDto> DeliveryAddresses { get; set; }
    }
    public class CreateClientCommandHandler : IRequestHandlerWrapper<CreateClientCommand, ClientDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ClientDto>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var entity = new Client
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Password = request.Password
            };

            entity.DomainEvents.Add(new ClientCreatedEvent(entity));

            await _context.Clients.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<ClientDto>(entity));
        }
    }
}
