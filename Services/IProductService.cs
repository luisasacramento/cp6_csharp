using SimpleStoreApi.Models;

namespace SimpleStoreApi.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product? GetById(Guid id);
    Product Create(Product product);
    bool Update(Guid id, Product product);
    bool Delete(Guid id);
}