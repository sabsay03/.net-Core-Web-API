using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Configuration.Commands;
using TESODEV_BACKEND_CHALLANGE.Data;
using TESODEV_BACKEND_CHALLANGE.Models;
using TESODEV_BACKEND_CHALLANGE.Models.Customers;

namespace TESODEV_BACKEND_CHALLANGE.Business.Customers
{
    public class CreateCustomerCommand:CommandBase<Customer>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string AddressLine { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
        public int CityCode { get; set; }


        private CreateCustomerCommand() { }

        public CreateCustomerCommand(string name,string email,string addressLine,string city,string country,int cityCode) {
            Name = name;
            Email = email;
            AddressLine = addressLine;
            City = city;
            Country = country;
            CityCode = cityCode;
        
        }
    }



    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand,Customer>
    {
        private readonly ShoppingContext _context;
        public CreateCustomerCommandHandler(ShoppingContext context) {
            _context = context;
        }


        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var address = Address.Create(request.AddressLine, request.City, request.Country, request.CityCode);
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            var customer = Customer.Create(request.Name, request.Email,address.Id);
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer;
        }
    }
}
