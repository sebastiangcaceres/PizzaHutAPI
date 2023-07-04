using FluentValidation;
using PizzaHutAPI.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Orders.Commands.Create
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateOrderCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(o => o.Comment)
                .MaximumLength(100).WithMessage("Comment must not exceed 100 characters.");

            //RuleFor(v => v.Name)
            //    .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            //    .MustAsync(BeUniqueName).WithMessage("The specified city already exists.")
            //    .NotEmpty().WithMessage("Name is required.");
        }

        //private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        //{
        //    //TODO: Control by uppercase and CultureInfo
        //    return await _context.Cities.AllAsync(x => x.Name != name, cancellationToken);
        //}
    }
}
