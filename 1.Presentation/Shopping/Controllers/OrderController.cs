using Microsoft.AspNetCore.Mvc;
using Shopping.Application;
using Shopping.Model;
using System.Text.Json;

namespace Shopping.Controllers;

[Produces("application/json")]
[Route("[Controller]/{name}/[Action]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> View(string name)
    {
        Order response;

        try
        {
            response = _orderService.ShowOrder(name);
        }
        catch (Exception ex)
        {
            response = new Order();
        }

        return Content(JsonSerializer.Serialize(response));
    }
}

