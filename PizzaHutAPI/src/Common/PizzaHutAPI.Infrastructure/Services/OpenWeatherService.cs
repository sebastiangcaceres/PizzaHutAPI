using PizzaHutAPI.Application.Common.Interfaces;
using PizzaHutAPI.Application.Common.Mapping;
using PizzaHutAPI.Application.Common.Models;
using PizzaHutAPI.Application.ExternalServices.OpenWeather.Request;
using PizzaHutAPI.Application.ExternalServices.OpenWeather.Response;
using PizzaHutAPI.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHutAPI.Infrastructure.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IHttpClientHandler _httpClient;

        private string ClientApi { get; } = "open-weather-api";

        public OpenWeatherService(IHttpClientHandler httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request, CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest<OpenWeatherRequest, OpenWeatherResponse>(ClientApi, string.Concat("weather?", StringExtensions
                .ParseObjectToQueryString(request, true)), cancellationToken, MethodType.Get, request);
        }
    }
}