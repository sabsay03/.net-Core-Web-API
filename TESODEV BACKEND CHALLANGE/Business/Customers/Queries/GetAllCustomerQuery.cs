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
using TESODEV_BACKEND_CHALLANGE.Models.Customers;

namespace TESODEV_BACKEND_CHALLANGE.Business.Customers
{
    public class GetAllCustomerQuery : IQuery<List<CustomerDto>>
    {
    }

  

    public class GetAllCustomerQueryHandler : IQueryHandler<GetAllCustomerQuery, List<CustomerDto>>
    {
        private readonly ShoppingContext _context;
        private readonly IMapper _mapper;


        public GetAllCustomerQueryHandler(ShoppingContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Include(c=>c.address).ProjectTo<CustomerDto>(_mapper.ConfigurationProvider).ToListAsync();

            return customer;

        }
    }

}
