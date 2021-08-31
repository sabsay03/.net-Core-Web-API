using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Business;
using TESODEV_BACKEND_CHALLANGE.Business.Customers;
using TESODEV_BACKEND_CHALLANGE.Business.Orders;
using TESODEV_BACKEND_CHALLANGE.Models;
using TESODEV_BACKEND_CHALLANGE.Models.Customers;

namespace TESODEV_BACKEND_CHALLANGE.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Address, AddressDto>();
        }
    }
}
