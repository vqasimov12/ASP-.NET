using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Abstract;

public interface IProductService
{
    List<Product> GetAll();
    List<Product> GetAllByCategory(int categoryId=0);
    Product GetById(int id);
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
}
