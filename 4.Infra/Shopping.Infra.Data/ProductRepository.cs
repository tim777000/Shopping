using Shopping.Model;

namespace Shopping.Infra.Data;

public class ProductRepository
{
    private readonly Dictionary<string, Product> _productRepository;

    public ProductRepository()
    {
        _productRepository = new Dictionary<string, Product>();
    }

    public List<Product> GetAllProduct()
    {
        List<Product> productList = new List<Product>();

        foreach(var product in _productRepository)
        {
            productList.Add(product.Value);
        }

        return productList;
    }

    public bool AddProduct(string productName, Product product)
    {
        if (_productRepository.ContainsKey(productName))
        {
            _productRepository[productName].Price = product.Price;
            _productRepository[productName].Inventory += product.Inventory;
        }
        else
        {
            _productRepository[productName] = product;
        }

        return true;
    }

    public Product GetProduct(string product)
    {
        return _productRepository[product];
    }
}

