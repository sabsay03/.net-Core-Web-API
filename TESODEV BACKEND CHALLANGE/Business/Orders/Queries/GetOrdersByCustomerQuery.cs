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

namespace TESODEV_BACKEND_CHALLANGE.Business.Orders.Queries
{
   
    public class GetOrdersByCustomerQuery : IQuery<List<OrderDto>>
    {
        public int Id { get; set; }

        public GetOrdersByCustomerQuery(int id)
        {
            Id = id;
        }
    }

    public class GetOrdersByCustomerQueryHandler : IQueryHandler<GetOrdersByCustomerQuery, List<OrderDto>>
    {
        private readonly ShoppingContext _context;
        private readonly IMapper _mapper;


        public GetOrdersByCustomerQueryHandler(ShoppingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetOrdersByCustomerQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Include(c => c.Address).Include(c => c.Product).Where(x => x.customer.Id == request.Id).ProjectTo<OrderDto>(_mapper.ConfigurationProvider).ToListAsync();

            return orders;

        }
    }
}
