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
    public class UpdateCustomerCommand : CommandBase<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string AddressLine { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
        public int CityCode { get; set; }


        private UpdateCustomerCommand() { }

        public UpdateCustomerCommand(int id,string name, string email, string addressLine, string city, string country, int cityCode)
        {
            Id = id;
            Name = name;
            Email = email;
            AddressLine = addressLine;
            City = city;
            Country = country;
            CityCode = cityCode;

        }
    }

    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, Customer>
    {
        private readonly ShoppingContext _context;
        public UpdateCustomerCommandHandler(ShoppingContext context)
        {
            _context = context;
        }


        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _context.Customers.FirstOrDefault(x=> x.Id==request.Id);
            var address = _context.Addresses.FirstOrDefault(x=> x.Id==customer.AddressId);
            customer.Update(request.Name, request.Email);
            address.Update(request.AddressLine, request.City, request.Country, request.CityCode);

            _context.Customers.Update(customer);
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
            return customer;
        }
    }



}







