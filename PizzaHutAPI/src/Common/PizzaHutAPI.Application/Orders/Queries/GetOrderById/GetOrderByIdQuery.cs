using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Application.Common.Interfaces;
using PizzaHutAPI.Application.Common.Models;
using PizzaHutAPI.Application.Dto;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequestWrapper<OrderDto>
    {
        public int OrderId { get; set; }
    }

    public class GetOrderByIdQueryHandler : IRequestHandlerWrapper<GetOrderByIdQuery, OrderDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Where(x => x.Id == request.OrderId)
                .ProjectToType<OrderDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return order != null ? ServiceResult.Success(order) : ServiceResult.Failed<OrderDto>(ServiceError.NotFound);
        }
    }
}
