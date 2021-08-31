using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Models;

namespace TESODEV_BACKEND_CHALLANGE.Validation
{
    public class OrderValidator:AbstractValidator<Order>
    {
        public OrderValidator() {

            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.Quantitiy).NotEmpty();
            RuleFor(c => c.Price).NotEmpty();
            RuleFor(c => c.Status).NotEmpty();
            RuleFor(c => c.AddressId).NotEmpty();
            RuleFor(c => c.ProductId).NotEmpty();
        }

    }
}
