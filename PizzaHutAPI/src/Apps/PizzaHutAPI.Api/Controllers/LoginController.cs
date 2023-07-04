using Microsoft.AspNetCore.Mvc;
using PizzaHutAPI.Application.ApplicationUser.Queries.GetToken;
using PizzaHutAPI.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHutAPI.Api.Controllers
{
    /// <summary>
    /// Login
    /// </summary>
    public class LoginController : BaseApiController
    {
        /// <summary>
        /// Login and get JWT token email: test@test.com password: Matech_1850
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> Login(GetTokenQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
