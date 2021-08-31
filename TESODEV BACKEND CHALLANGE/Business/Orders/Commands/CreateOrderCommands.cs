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
    public class CreateOrderCommands:CommandBase<Order>
    {
        public int CustomerId { get; set; }

        public int Quantitiy { get; set; }

        public double Price { get; set; }

        public string Status { get; set; }

        public int ProductId { get; set; }
        public string AddressLine { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
        public int CityCode { get; set; }


        private CreateOrderCommands() { }

        public CreateOrderCommands(int customerId,int quantitiy,double price,string status,int productId, string addressLine, string city, string country, int cityCode)
        {
            CustomerId = customerId;
            Quantitiy = quantitiy;
            Price = price;
            Status = status;
            ProductId = productId;
            AddressLine = addressLine;
            City = city;
            Country = country;
            CityCode = cityCode;
        }

    }

    public class CreateOrderCommandsHandler : ICommandHandler<CreateOrderCommands, Order>
    {
        private readonly ShoppingContext _context;
        public CreateOrderCommandsHandler(ShoppingContext context)
        {
            _context = context;
        }


        public async Task<Order> Handle(CreateOrderCommands request, CancellationToken cancellationToken)
        {
            var address = Address.Create(request.AddressLine, request.City, request.Country, request.CityCode);
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            var order = Order.Create(request.CustomerId, request.Quantitiy, request.Price, request.Status, request.ProductId,address.Id);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }


}
