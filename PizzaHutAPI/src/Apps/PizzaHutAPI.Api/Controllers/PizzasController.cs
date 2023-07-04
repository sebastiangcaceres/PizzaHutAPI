using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaHutAPI.Application.Common.Models;
using PizzaHutAPI.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PizzaHutAPI.Application.Pizzas.Queries.GetPizzas;

namespace PizzaHutAPI.Api.Controllers
{
    /// <summary>
    /// Pizzas
    /// </summary>
    public class PizzasController : BaseApiController
    {
        /// <summary>
        /// Get a list of pizzas
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<PizzaDto>>>> GetAllPizzas(CancellationToken cancellationToken)
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllPizzasQuery(), cancellationToken));
        }
    }
}
