using Shopping.Infra.Data;
using Shopping.Model;

namespace Shopping.Application;

public class ProductService
{
    private readonly ProductRepository _productRepository;

    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public ProductList ShowProduct()
    {
        return new ProductList() { Products = _productRepository.GetAllProduct() };
    }

    public bool AddProduct(Product product)
    {
        return _productRepository.AddProduct(product.Name, product);
    }
}

