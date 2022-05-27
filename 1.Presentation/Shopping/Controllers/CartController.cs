using Microsoft.AspNetCore.Mvc;
using Shopping.Application;
using Shopping.Model;
using System.Text.Json;

namespace Shopping.Controllers;

[Produces("application/json")]
[Route("[Controller]/{name}/[Action]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<IActionResult> View(string name)
    {
        Cart response;

        try
        {
            response = _cartService.ShowCart(name);
        }
        catch (Exception ex)
        {
            response = new Cart();
        }

        return Content(JsonSerializer.Serialize(response));
    }

    [HttpPost]
    public async Task<IActionResult> Add(string name, CustomerProduct product)
    {
        Cart response;

        try
        {
            response = _cartService.AddProductToCart(name, product);
        }
        catch (Exception ex)
        {
            response = new Cart();
        }

        return Content(JsonSerializer.Serialize(response));
    }

    [HttpGet]
    public async Task<IActionResult> Checkout(string name)
    {
        bool response;

        try
        {
            response = _cartService.Checkout(name);
        }
        catch (Exception ex)
        {
            response = false;
        }

        return Content(JsonSerializer.Serialize(response));
    }
}

