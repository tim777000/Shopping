using Shopping.Infra.Data;
using Shopping.Model;

namespace Shopping.Application;

public class CartService
{
    private readonly OrderService _orderService;
    private readonly ProductRepository _productRepository;
    private readonly CartRepository _cartRepository;

    public CartService(OrderService orderService,
        ProductRepository productRepository,
        CartRepository cartRepository)
    {
        _orderService = orderService;
        _productRepository = productRepository;
        _cartRepository = cartRepository;
    }

    public Cart ShowCart(string user)
    {
        return _cartRepository.GetCart(user);
    }

    public Cart AddProductToCart(string user, CustomerProduct product)
    {
        var productInfo = _productRepository.GetProduct(product.Name);
        if (product.Amount > productInfo.Inventory)
            throw new Exception("Not Enough Inventory!");
        var customerProduct = new CustomerProduct()
        {
            Name = product.Name,
            Price = productInfo.Price,
            Amount = product.Amount
        };
        return _cartRepository.AddProductToCart(user, customerProduct);
    }

    public bool Checkout(string user)
    {
        var userCart = _cartRepository.GetCart(user);
        _cartRepository.CheckoutCart(user);
        _orderService.Checkout(user, userCart);
        return true;
    }
}

