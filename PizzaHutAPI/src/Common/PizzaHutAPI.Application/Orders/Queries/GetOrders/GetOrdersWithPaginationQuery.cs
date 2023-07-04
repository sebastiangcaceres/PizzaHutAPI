using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Application.Common.Interfaces;
using PizzaHutAPI.Application.Common.Mapping;
using PizzaHutAPI.Application.Common.Models;
using PizzaHutAPI.Application.Common.Security;
using PizzaHutAPI.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Orders.Queries.GetOrders
{
    [Authorize(Roles = "Administrator")]
    public class GetOrdersWithPaginationQuery : IRequestWrapper<PaginatedList<OrderDto>>
    {
        public int OrderStatusId { get; set; }
        public int ClientId { get; set; }
        public DateTime? CreatedAtFrom { get; set; }
        public DateTime? CreatedAtTo { get; set; }
        public DateTime? DeliveryTimeFrom { get; set; }
        public DateTime? DeliveryTimeTo { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetOrdersWithPaginationQueryHandler : IRequestHandlerWrapper<GetOrdersWithPaginationQuery, PaginatedList<OrderDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrdersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<PaginatedList<OrderDto>>> Handle(GetOrdersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            PaginatedList<OrderDto> list = await _context.Orders
                .Where(x => x.OrderStatusId == request.OrderStatusId || request.OrderStatusId == 0)
                .Where(x => x.ClientId == request.ClientId || request.ClientId == 0)
                .Where(x => x.CreatedAt <= request.CreatedAtFrom || request.CreatedAtFrom == null)
                .Where(x => x.CreatedAt >= request.CreatedAtTo || request.CreatedAtTo == null)
                .Where(x => x.DeliveryTime <= request.DeliveryTimeFrom || request.DeliveryTimeFrom == null)
                .Where(x => x.DeliveryTime >= request.DeliveryTimeTo || request.DeliveryTimeTo == null)
                .ProjectToType<OrderDto>(_mapper.Config)
                .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

            return list.Items.Any() ? ServiceResult.Success(list) : ServiceResult.Failed<PaginatedList<OrderDto>>(ServiceError.NotFound);
        }
    }
}
