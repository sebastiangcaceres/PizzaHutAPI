using PizzaHutAPI.Application.Common.Models;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
