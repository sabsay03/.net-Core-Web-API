using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Business.Orders;
using TESODEV_BACKEND_CHALLANGE.Configuration.Queries;
using TESODEV_BACKEND_CHALLANGE.Data;

namespace TESODEV_BACKEND_CHALLANGE.Business.Orders.Queries
{

    public class GetOrderDetailQuery : IQuery<OrderDto>
    {
        public int Id { get; set; }

        public GetOrderDetailQuery(int id) {
            Id = id;
        }
    }

    public class GetOrderDetailHandler : IQueryHandler<GetOrderDetailQuery, OrderDto>
    {
        private readonly ShoppingContext _context;
        private readonly IMapper _mapper;


        public GetOrderDetailHandler(ShoppingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Include(c => c.Address).Include(c => c.customer).Include(c => c.Product).Where(x => x.Id == request.Id).ProjectTo<OrderDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return orders;

        }
    }
}