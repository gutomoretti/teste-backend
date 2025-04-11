using Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;
using Ambev.DeveloperEvaluation.Application.Orders.DeleteOrder;
using Ambev.DeveloperEvaluation.Application.Orders.GetAllOrders;
using Ambev.DeveloperEvaluation.Application.Orders.GetOrder;
using Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.DeleteOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetAllOrders;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(IMediator mediator, Mapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            var command = _mapper.Map<CreateOrderCommand>(request);
            var result = await _mediator.Send(command);
            var response = _mapper.Map<CreateOrderResponse>(result);
            return CreatedAtAction(nameof(GetById), new { id = response.OrderId }, response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetOrderCommand { Id = id });
            var response = _mapper.Map<GetOrderResponse>(result);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllOrdersCommand());
            var response = _mapper.Map<List<GetAllOrdersResponse>>(result);
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateOrderRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID in URL does not match request payload");

            var command = _mapper.Map<UpdateOrderCommand>(request);
            var result = await _mediator.Send(command);
            var response = _mapper.Map<UpdateOrderResponse>(result);
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new DeleteOrderRequest { Id = id };
            var command = _mapper.Map<DeleteOrderCommand>(request);
            var result = await _mediator.Send(command);
            var response = _mapper.Map<DeleteOrderResponse>(result);

            if (!response.Success)
                return NotFound();

            return NoContent();
        }
    }
}
