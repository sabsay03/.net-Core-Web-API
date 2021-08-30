﻿using Microsoft.EntityFrameworkCore;
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
    public class GetCustomerDetailsQuery:IQuery<Customer>
    {
        public GetCustomerDetailsQuery(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; }

    }

    public class GetCustomerDetailsQueryHandler : IQueryHandler<GetCustomerDetailsQuery, Customer>
    {
        private readonly ShoppingContext _context;


        public GetCustomerDetailsQueryHandler(ShoppingContext context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync((x => x.Id == request.CustomerId));

              return customer;

        }
    }



}
