using PizzaHutAPI.Application.Common.Models;
using PizzaHutAPI.Application.ExternalServices.OpenWeather.Request;
using PizzaHutAPI.Application.ExternalServices.OpenWeather.Response;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Common.Interfaces
{
    public interface IOpenWeatherService
    {
        Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request,
            CancellationToken cancellationToken);
    }
}