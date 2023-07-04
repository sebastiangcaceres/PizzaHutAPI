using FluentAssertions;
using NUnit.Framework;
using PizzaHutAPI.Application.Cities.Commands.Create;
using PizzaHutAPI.Application.Cities.Commands.Delete;
using PizzaHutAPI.Application.Common.Exceptions;
using PizzaHutAPI.Domain.Entities;
using System.Threading.Tasks;
using static PizzaHutAPI.Application.IntegrationTests.Testing;

namespace PizzaHutAPI.Application.IntegrationTests.Cities.Commands
{
    public class DeleteCityTests : TestBase
    {
        [Test]
        public void ShouldRequireValidCityId()
        {
            var command = new DeleteCityCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteCity()
        {
            await RunAsDefaultUserAsync();

            var city = await SendAsync(new CreateCityCommand("Kayseri"));

            await SendAsync(new DeleteCityCommand
            {
                Id = city.Data.Id
            });

            var list = await FindAsync<City>(city.Data.Id);

            list.Should().BeNull();
        }
    }
}
