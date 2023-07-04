using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaHutAPI.Application.Common.Models;
using PizzaHutAPI.Application.Dto;
using System.Threading.Tasks;
using System.Threading;
using PizzaHutAPI.Application.Orders.Commands.Create;
using PizzaHutAPI.Application.Orders.Queries.GetOrderById;
using PizzaHutAPI.Application.Orders.Commands.Update;
using PizzaHutAPI.Application.Orders.Commands.Delete;
using System.Collections.Generic;
using PizzaHutAPI.Application.Orders.Queries.GetOrders;

namespace PizzaHutAPI.Api.Controllers
{

    /// <summary>
    /// Orders
    /// </summary>
    public class OrdersController : BaseApiController
    {
        /// <summary>
        /// Get orders with pagination and filter by order status, customer, date and time of creation and date and time of delivery
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<PaginatedList<OrderDto>>>> GetOrders(GetOrdersWithPaginationQuery query, CancellationToken cancellationToken)
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(query, cancellationToken));
        }
        
        /// <summary>
        /// Create an order
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<OrderDto>>> Create(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Get Order by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<OrderDto>>> GetOrderById(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetOrderByIdQuery { OrderId = id }, cancellationToken));
        }

        /// <summary>
        /// Update order
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ServiceResult<OrderDto>>> Update(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Delete order by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<OrderDto>>> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteOrderCommand { Id = id }, cancellationToken));
        }
    }
}
