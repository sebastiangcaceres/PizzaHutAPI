using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Clients.Commands.Create
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateClientCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
                //.MustAsync(BeUniqueName).WithMessage("The specified city already exists.")
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(s => s.Surname)
                .NotEmpty().WithMessage("Surname is required.");

            RuleFor(m => m.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MustAsync(BeUniqueEMail).WithMessage("The specified email already exists.");

            //        RuleFor(model => model.TransDrops)
            //.Must(collection => collection == null || collection.All(item => item.HasValue))
            //.WithMessage("Please fill all items");

            RuleFor(d => d.DeliveryAddresses)
                .Must(collection => collection != null && collection.All(item => item.Address!=null))
                .WithMessage("Almost one Delivery Address is required.");
        }

        private async Task<bool> BeUniqueEMail(string email, CancellationToken cancellationToken)
        {
            //TODO: Control by uppercase and CultureInfo
            return await _context.Clients.AllAsync(x => x.Email != email, cancellationToken);
        }
    }
}
