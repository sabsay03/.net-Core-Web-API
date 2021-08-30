using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TESODEV_BACKEND_CHALLANGE.Business.Customers;
using TESODEV_BACKEND_CHALLANGE.Data;
using TESODEV_BACKEND_CHALLANGE.Models;
using TESODEV_BACKEND_CHALLANGE.Models.Customers;

namespace TESODEV_BACKEND_CHALLANGE.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ShoppingContext _context;


        public CustomersController(IMediator mediator,ShoppingContext context)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _context =context;
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] CustomerDto request)
        {
            var customer=await _mediator.Send(new CreateCustomerCommand(request.Name,request.Email,request.AddressId));


            return Ok(customer);
        }


        [HttpGet("{customerId}")]
        [ValidateAntiForgeryToken]

        public ActionResult<Customer> Get( int customerId)
        {

            var customer =  _context.Customers.FirstOrDefaultAsync(x=>x.Id==customerId);


            return Ok(customer);
        }


    }
}