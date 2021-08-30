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
        public int AddressId { get; set; }

        private CreateCustomerCommand() { }

        public CreateCustomerCommand(string name,string email,int addressId) {
            Name = name;
            Email = email;
            AddressId = addressId;
        
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
            var customer = Customer.Create(request.Name, request.Email,request.AddressId);

            await _context.Customers.AddAsync(customer);

            return customer;
        }
    }
}
