using MapsterMapper;
using Microsoft.IdentityModel.Tokens;
using PizzaHutAPI.Application.Common.Exceptions;
using PizzaHutAPI.Application.Common.Interfaces;
using PizzaHutAPI.Application.Common.Models;
using PizzaHutAPI.Application.Dto;
using PizzaHutAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Orders.Commands.Update
{
    public class UpdateOrderCommand : IRequestWrapper<OrderDto>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int DeliveryAddressId { get; set; }
        public decimal OrderCost { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public string Comment { get; set; }
    }

    public class UpdateOrderCommandHandler : IRequestHandlerWrapper<UpdateOrderCommand, OrderDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<OrderDto>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }
            //if (!string.IsNullOrEmpty(request.Status))
            //    entity.Status = request.Status;
            if (!string.IsNullOrEmpty(request.Comment))
                entity.Comment=request.Comment;
            //entity.Active = request.Active;

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<OrderDto>(entity));
        }
    }
}
