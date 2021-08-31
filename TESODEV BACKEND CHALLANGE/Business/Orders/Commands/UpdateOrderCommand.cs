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
    public class UpdateOrderCommand:CommandBase<Order>
    {
        public int Id { get; set; }
        public int Quantitiy { get; set; }

        public double Price { get; set; }

        public int ProductId { get; set; }
        public string AddressLine { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
        public int CityCode { get; set; }

        private UpdateOrderCommand() { }

        public UpdateOrderCommand(int id,int quantitiy,double price,int productId, string addressLine, string city, string country, int cityCode) {

            Id = id;
            Quantitiy = quantitiy;
            Price = price;
            ProductId = productId;
            AddressLine = addressLine;
            City = city;
            Country = country;
            CityCode = cityCode;

        }
    }

    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateOrderCommand, Order>
    {
        private readonly ShoppingContext _context;
        public UpdateCustomerCommandHandler(ShoppingContext context)
        {
            _context = context;
        }


        public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == request.Id);
            var address = _context.Addresses.FirstOrDefault(x => x.Id == order.AddressId);
            order.Update(request.Quantitiy,request.Price,request.ProductId);
            address.Update(request.AddressLine, request.City, request.Country, request.CityCode);

            _context.Orders.Update(order);
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
            return order;
        }
    }



}
