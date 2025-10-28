using SimpleStoreApi.Models;

namespace SimpleStoreApi.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new();

    public ProductService()
    {
        _products.AddRange(new[]
        {
            new Product { Name = "Camiseta", Description = "Camiseta 100% algodão", Price = 49.90m, Stock = 10 },
            new Product { Name = "Caneca", Description = "Caneca cerâmica 350ml", Price = 29.50m, Stock = 20 },
        });
    }

    public IEnumerable<Product> GetAll() => _products;
    public Product? GetById(Guid id) => _products.FirstOrDefault(p => p.Id == id);

    public Product Create(Product product)
    {
        product.Id = Guid.NewGuid();
        _products.Add(product);
        return product;
    }

    public bool Update(Guid id, Product product)
    {
        var existing = GetById(id);
        if (existing == null) return false;

        existing.Name = product.Name;
        existing.Description = product.Description;
        existing.Price = product.Price;
        existing.Stock = product.Stock;
        return true;
    }

    public bool Delete(Guid id)
    {
        var existing = GetById(id);
        if (existing == null) return false;
        return _products.Remove(existing);
    }
}