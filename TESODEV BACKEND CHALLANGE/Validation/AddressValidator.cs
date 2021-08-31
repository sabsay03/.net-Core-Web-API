using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Models;

namespace TESODEV_BACKEND_CHALLANGE.Validation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator() {
            RuleFor(c => c.AddressLine).NotEmpty();
            RuleFor(c => c.City).NotEmpty();
            RuleFor(c => c.Country).NotEmpty();
            RuleFor(c => c.CityCode).NotEmpty();
        }
    }
}
