using FluentAssertions;
using NUnit.Framework;
using PizzaHutAPI.Application.Cities.Queries.GetCities;
using PizzaHutAPI.Domain.Entities;
using System.Threading.Tasks;
using static PizzaHutAPI.Application.IntegrationTests.Testing;

namespace PizzaHutAPI.Application.IntegrationTests.Cities.Queries
{
    public class GetAllCitiesTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllCities()
        {
            await RunAsDefaultUserAsync();

            await AddAsync(new City
            {
                Name = "Manisa",
            });

            var query = new GetAllCitiesQuery();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
            result.Data.Count.Should().BeGreaterThan(0);
        }
    }
}