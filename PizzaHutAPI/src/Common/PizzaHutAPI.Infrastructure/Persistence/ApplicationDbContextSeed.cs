using Microsoft.AspNetCore.Identity;
using PizzaHutAPI.Domain.Entities;
using PizzaHutAPI.Infrastructure.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHutAPI.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var userRole = new IdentityRole("User");

            if (roleManager.Roles.All(r => r.Name != userRole.Name))
            {
                await roleManager.CreateAsync(userRole);
            }

            var defaultUser = new ApplicationUser { UserName = "iayti", Email = "test@test.com" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Matech_1850");
                await userManager.AddToRolesAsync(defaultUser, new[] { administratorRole.Name });
            }

            var sampleUser = new ApplicationUser { UserName = "sebas", Email = "seba@seba.com" };

            if (userManager.Users.All(u => u.UserName != sampleUser.UserName))
            {
                await userManager.CreateAsync(sampleUser, "seba123");
                //await userManager.AddToRolesAsync(sampleUser, new[] { userRole.Name });
            }
        }

        public static async Task SeedSamplePizzaDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Pizzas.Any())
            {
                context.Pizzas.Add(new Pizza
                {
                    Name = "Pepperoni",
                    Price = 10

                });

                context.Pizzas.Add(new Pizza
                {
                    Name = "Cheese",
                    Price = 9

                });

                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedSampleOrderStatusDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.OrderStatuses.Any())
            {
                context.OrderStatuses.Add(
                    new OrderStatus { Name = "Pending" }
                );
                context.OrderStatuses.Add(
                    new OrderStatus { Name = "InProgress" }
                );
                context.OrderStatuses.Add(
                    new OrderStatus { Name = "Delivered" }
                );
                context.OrderStatuses.Add(
                    new OrderStatus { Name = "Cancelled" }
                );

                await context.SaveChangesAsync();
            }
        }

    }
}
