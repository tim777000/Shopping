namespace Shopping.Model;

public class Order
{
    public int Price { get; set; }

    public List<CustomerProduct> Products { get; set; }
}

