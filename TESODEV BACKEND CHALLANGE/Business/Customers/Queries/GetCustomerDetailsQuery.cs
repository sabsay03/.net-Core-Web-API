using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Configuration.Queries;
using TESODEV_BACKEND_CHALLANGE.Data;
using TESODEV_BACKEND_CHALLANGE.Models;
using TESODEV_BACKEND_CHALLANGE.Models.Customers;

namespace TESODEV_BACKEND_CHALLANGE.Business.Customers
{
    public class GetCustomerDetailsQuery:IQuery<CustomerDto>
    {
        public GetCustomerDetailsQuery(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; }

    }

    public class GetCustomerDetailsQueryHandler : IQueryHandler<GetCustomerDetailsQuery, CustomerDto>
    {
        private readonly ShoppingContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailsQueryHandler(ShoppingContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Include(a=>a.address).Include(o=>o.Orders).Where(s=>s.Id==request.CustomerId).ProjectTo<CustomerDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

            
              return customer;

        }
    }



}
