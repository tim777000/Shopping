using Shopping.Model;

namespace Shopping.Infra.Data;

public class OrderRepository
{
    private readonly Dictionary<string, Order> _orderRepository;

    public OrderRepository()
    {
        _orderRepository = new Dictionary<string, Order>();
    }

    public Order GetOrder(string user)
    {
        if (!_orderRepository.ContainsKey(user))
        {
            _orderRepository[user] = new Order();
            _orderRepository[user].Products = new List<CustomerProduct>();
        }

        return _orderRepository[user];
    }

    public bool AddOrder(string user, Order order)
    {
        _orderRepository[user] = new Order();
        _orderRepository[user].Products = new List<CustomerProduct>();
        _orderRepository[user] = order;
        return true;
    }
}

