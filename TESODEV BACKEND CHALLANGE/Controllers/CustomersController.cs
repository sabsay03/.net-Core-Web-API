using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
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


        public CustomersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerRequest request)
        {
            var customer = await _mediator.Send(new CreateCustomerCommand(request.Name, request.Email,request.AddressLine,request.City,request.Country,request.CityCode));


            return Ok(customer);
        }


        [HttpPut("{customerId}")]
        public async Task<IActionResult> Update(int customerId,[FromBody] CustomerRequest request)
        {
            var customer = await _mediator.Send(new UpdateCustomerCommand(customerId,request.Name, request.Email, request.AddressLine, request.City, request.Country, request.CityCode));


            return Ok(customer);
        }


        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> Get(int customerId, CancellationToken cancellationToken)
        {


            var customer = await _mediator.Send(new GetCustomerDetailsQuery(customerId));


            return Ok(customer);
        }


        [HttpGet]
        public async Task<ActionResult<Customer>> GetAll(CancellationToken cancellationToken)
        {


            var customer = await _mediator.Send(new GetAllCustomerQuery());


            return Ok(customer);
        }



        [HttpDelete("{customerId}")]
        public async Task<ActionResult<Customer>> Delete(int customerId, CancellationToken cancellationToken)
        {


            var customer = await _mediator.Send(new DeleteCustomerCommand(customerId));


            return NoContent();
        }


    }
}