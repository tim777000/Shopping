using Shopping.Infra.Data;
using Shopping.Model;

namespace Shopping.Application;

public class OrderService
{
    private readonly ProductRepository _productRepository;
    private readonly OrderRepository _orderRepository;

    public OrderService(ProductRepository productRepository,
        OrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    public Order ShowOrder(string user)
    {
        return _orderRepository.GetOrder(user);
    }

    public bool Checkout(string user, Cart cart)
    {
        var order = new Order() { Products = cart.Products, Price = cart.Price };

        foreach(var product in cart.Products)
        {
            _productRepository.AddProduct(product.Name, new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Inventory = (-1)*product.Amount
            });
        }

        return _orderRepository.AddOrder(user, order);
    }
}

