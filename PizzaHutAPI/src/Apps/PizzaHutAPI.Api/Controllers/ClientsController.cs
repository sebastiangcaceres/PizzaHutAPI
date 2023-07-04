using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaHutAPI.Application.ApplicationUser.Queries.GetToken;
using PizzaHutAPI.Application.Clients.Commands.Create;
using PizzaHutAPI.Application.Common.Models;
using System.Threading.Tasks;
using System.Threading;
using PizzaHutAPI.Application.Dto;

namespace PizzaHutAPI.Api.Controllers
{
    /// <summary>
    /// Clients
    /// </summary>
    public class ClientsController : BaseApiController
    {
        /// <summary>
        /// Client registration. 
        /// The client specifies the name, surname and mail. 
        /// Mail must be unique. 
        /// Delivery addresses are specified during registration.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<ClientDto>>> Register(CreateClientCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

    }
}
