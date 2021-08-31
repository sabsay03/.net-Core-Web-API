using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Configuration.Commands;
using TESODEV_BACKEND_CHALLANGE.Data;
using TESODEV_BACKEND_CHALLANGE.Models.Customers;

namespace TESODEV_BACKEND_CHALLANGE.Business.Customers
{
    public class DeleteCustomerCommand:CommandBase<int>
    {
        public int Id { get; set; }

        private DeleteCustomerCommand() { }

        public DeleteCustomerCommand(int id )
        {
            Id = id;

        }
    }


    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand, int>
    {
        private readonly ShoppingContext _context;
        public DeleteCustomerCommandHandler(ShoppingContext context)
        {
            _context = context;
        }


        public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == request.Id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }

    }


}
