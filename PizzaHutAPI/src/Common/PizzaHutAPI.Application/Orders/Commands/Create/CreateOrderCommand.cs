using MapsterMapper;
using PizzaHutAPI.Application.Clients.Commands.Create;
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

namespace PizzaHutAPI.Application.Orders.Commands.Create
{
    public record CreateOrderCommand : IRequestWrapper<OrderDto>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int DeliveryAddressId { get; set; }
        public List<PizzaDto> Pizzas { get; set; }
        public decimal OrderCost { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public string Comment { get; set; }
    }
    public class CreateOrderCommandHandler : IRequestHandlerWrapper<CreateOrderCommand, OrderDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = new Order
            {
                Id = request.Id,
                ClientId = request.ClientId,
                DeliveryAddressId = request.DeliveryAddressId,
                OrderCost = request.OrderCost,
                CreatedAt = request.CreatedAt,
                DeliveryTime = request.DeliveryTime,
                Comment = request.Comment
            };

            entity.DomainEvents.Add(new OrderCreatedEvent(entity));

            await _context.Orders.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<OrderDto>(entity));
        }
    }
}
