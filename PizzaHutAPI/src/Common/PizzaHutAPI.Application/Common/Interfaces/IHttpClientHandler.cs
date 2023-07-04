using PizzaHutAPI.Application.Common.Models;
using PizzaHutAPI.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Common.Interfaces
{
    public interface IHttpClientHandler
    {
        Task<ServiceResult<TResult>> GenericRequest<TRequest, TResult>(string clientApi, string url,
            CancellationToken cancellationToken,
            MethodType method = MethodType.Get,
            TRequest requestEntity = null)
            where TResult : class where TRequest : class;
    }
}