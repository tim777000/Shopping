using Shopping.Model;

namespace Shopping.Infra.Data;

public class CartRepository
{
    private readonly Dictionary<string, Cart> _cartRepository;

    public CartRepository()
    {
        _cartRepository = new Dictionary<string, Cart>();
    }

    public Cart GetCart(string user)
    {
        if (!_cartRepository.ContainsKey(user))
        {
            _cartRepository[user] = new Cart();
            _cartRepository[user].Products = new List<CustomerProduct>();
        }

        return _cartRepository[user];
    }

    public Cart AddProductToCart(string user, CustomerProduct product)
    {
        if (_cartRepository.ContainsKey(user))
        {
            _cartRepository[user].Products.Add(product);
        }
        else
        {
            _cartRepository[user] = new Cart();
            _cartRepository[user].Products = new List<CustomerProduct>();
            _cartRepository[user].Products.Add(product);
        }
        _cartRepository[user].Price = _cartRepository[user].Products.Sum(p => p.Price*p.Amount);

        return _cartRepository[user];
    }

    public bool CheckoutCart(string user)
    {
        return _cartRepository.Remove(user);
    }
}

