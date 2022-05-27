using Microsoft.AspNetCore.Mvc;
using Shopping.Application;
using Shopping.Model;
using System.Text.Json;

namespace Shopping.Controllers;

[Produces("application/json")]
[Route("[Controller]/[Action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> View()
    {
        ProductList response;

        try
        {
             response = _productService.ShowProduct();
        }
        catch (Exception ex)
        {
            response = new ProductList();
        }

        return Content(JsonSerializer.Serialize(response));
    }

    [HttpPost]
    public async Task<IActionResult> Add(Product product)
    {
        bool response;

        try
        {
            response = _productService.AddProduct(product);
        }
        catch (Exception ex)
        {
            response = false;
        }

        return Content(JsonSerializer.Serialize(response));
    }
}

