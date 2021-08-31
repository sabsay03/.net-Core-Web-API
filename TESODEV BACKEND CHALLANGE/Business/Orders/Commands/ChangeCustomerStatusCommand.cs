using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Configuration.Commands;
using TESODEV_BACKEND_CHALLANGE.Data;
using TESODEV_BACKEND_CHALLANGE.Models;

namespace TESODEV_BACKEND_CHALLANGE.Business.Orders.Commands
{
    public class ChangeCustomerStatusCommand : CommandBase<Order>
    {
        public int Id { get; set; }
        public string Status { get; set; }


        public ChangeCustomerStatusCommand(int id,string status) {
            Id = id;
            Status = status;
        }
    }


    public class ChangeCustomerStatusCommandHandler : ICommandHandler<ChangeCustomerStatusCommand, Order>
    {
        private readonly ShoppingContext _context;
        public ChangeCustomerStatusCommandHandler(ShoppingContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(ChangeCustomerStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x=>x.Id==request.Id);

            order.ChangeStatus(request.Status);
             _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }

}
