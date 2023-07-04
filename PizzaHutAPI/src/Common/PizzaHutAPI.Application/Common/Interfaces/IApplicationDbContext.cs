using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Pizza> Pizzas { get; set; }

        DbSet<Client> Clients { get; set; }

        DbSet<DeliveryAddress> DeliveryAddresses { get; set; }

        DbSet<OrderStatus> OrderStatuses { get; set; }
        DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
