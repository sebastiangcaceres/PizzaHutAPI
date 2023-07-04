using FluentValidation;
using PizzaHutAPI.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Orders.Commands.Update
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateOrderCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Comment)
                .MaximumLength(100).WithMessage("Comment must not exceed 100 characters.");

            RuleFor(v => v.Id).NotNull();
        }
    }
}
