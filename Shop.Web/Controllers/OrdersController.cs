using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.UseCases.Orders.Commands.CreateOrder;
using Shop.Web.UseCases.Orders.Commands.DeleteOrder;
using Shop.Web.UseCases.Orders.Commands.UpdateOrder;
using Shop.Web.UseCases.Orders.Dtos;
using Shop.Web.UseCases.Orders.Queries;

namespace Shop.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ISender _sender;

    public OrdersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrder([FromRoute] Guid id, CancellationToken token)
    {
        var result = await _sender.Send(new GetOrderQuery { Id = id }, token);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto, CancellationToken token)
    {
        var id = await _sender.Send(new CreateOrderCommand { Dto = dto }, token);

        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateOrder([FromRoute] Guid id, [FromBody] UpdateOrderDto dto, CancellationToken token)
    {
        await _sender.Send(new UpdateOrderCommand { Id = id, Dto = dto }, token);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOrder([FromRoute] Guid id, CancellationToken token)
    {
        await _sender.Send(new DeleteOrderCommand { Id = id  }, token);

        return Ok();
    }
}