using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TESODEV_BACKEND_CHALLANGE.Business.Orders;
using TESODEV_BACKEND_CHALLANGE.Business.Orders.Commands;
using TESODEV_BACKEND_CHALLANGE.Business.Orders.Queries;
using TESODEV_BACKEND_CHALLANGE.Data;
using TESODEV_BACKEND_CHALLANGE.Models;

namespace TESODEV_BACKEND_CHALLANGE.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : Controller
    {

        private readonly IMediator _mediator;


        public OrdersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrdersRequest request)
        {
            var order = await _mediator.Send(new CreateOrderCommands(
                request.CustomerId, request.Quantitiy, request.Price,
                request.Status,request.ProductId,request.AddressLine,
                request.City,request.Country,request.CityCode));

            return NoContent();
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> Update(int orderId, [FromBody] OrderUpdateRequest request)
        {
            var customer = await _mediator.Send(new UpdateOrderCommand(
                orderId, request.Quantitiy, request.Price,
                request.ProductId, request.AddressLine,
                request.City, request.Country, request.CityCode));


            return Ok(customer);
        }


        [HttpPut("/api/Orders/statu/{orderId}")]
        public async Task<IActionResult> ChangeStatus(int orderId, [FromQuery] string status)
        {
            var customer = await _mediator.Send(new ChangeCustomerStatusCommand(orderId,status));


            return Ok(customer);
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult<Order>> Delete(int orderId, CancellationToken cancellationToken)
        {
            var order = await _mediator.Send(new DeleteOrderCommands(orderId));
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll(CancellationToken cancellationToken)
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> Get(int orderId, CancellationToken cancellationToken)
        {
            var order = await _mediator.Send(new GetOrderDetailQuery(orderId));

            return Ok(order);
        }
        [HttpGet("/api/orders/by/{customerId}")]
        public async Task<ActionResult<List<Order>>> GetOrdersByCustomer(int customerId, CancellationToken cancellationToken)
        {
            var orders = await _mediator.Send(new GetOrdersByCustomerQuery(customerId));

            return Ok(orders);
        }



    }
}
