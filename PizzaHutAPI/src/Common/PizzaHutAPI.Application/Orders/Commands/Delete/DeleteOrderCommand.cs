using MapsterMapper;
using Microsoft.EntityFrameworkCore;
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

namespace PizzaHutAPI.Application.Orders.Commands.Delete
{
    public class DeleteOrderCommand : IRequestWrapper<OrderDto>
    {
        public int Id { get; set; }
    }

    public class DeleteOrderCommandHandler : IRequestHandlerWrapper<DeleteOrderCommand, OrderDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<OrderDto>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            _context.Orders.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<OrderDto>(entity));
        }
    }
}
