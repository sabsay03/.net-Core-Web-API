using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Configuration.Commands;
using TESODEV_BACKEND_CHALLANGE.Data;

namespace TESODEV_BACKEND_CHALLANGE.Business.Orders.Commands
{

    public class DeleteOrderCommands : CommandBase<int>
    {
        public int Id { get; set; }

        private DeleteOrderCommands() { }

        public DeleteOrderCommands(int id)
        {
            Id = id;

        }
    }


    public class DeleteOrderCommandsHandler : ICommandHandler<DeleteOrderCommands, int>
    {
        private readonly ShoppingContext _context;
        public DeleteOrderCommandsHandler(ShoppingContext context)
        {
            _context = context;
        }


        public async Task<int> Handle(DeleteOrderCommands request, CancellationToken cancellationToken)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == request.Id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

    }
}