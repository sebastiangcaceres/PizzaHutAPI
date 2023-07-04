using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Application.Common.Interfaces;
using PizzaHutAPI.Application.Common.Models;
using PizzaHutAPI.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mapster;

namespace PizzaHutAPI.Application.Pizzas.Queries.GetPizzas
{
    public class GetAllPizzasQuery : IRequestWrapper<List<PizzaDto>>
    {

    }
    public class GetPizzasQueryHandler : IRequestHandlerWrapper<GetAllPizzasQuery, List<PizzaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPizzasQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<PizzaDto>>> Handle(GetAllPizzasQuery request, CancellationToken cancellationToken)
        {
            List<PizzaDto> list = await _context.Pizzas
                //.Include(x => x.Districts)
                //.ThenInclude(c => c.Villages)
                .ProjectToType<PizzaDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<PizzaDto>>(ServiceError.NotFound);
        }
    }
}
