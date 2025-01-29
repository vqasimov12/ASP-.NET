using Ecommerce.Application.Abstract;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Concrete;

public class ProductService(IProductDal productDal) : IProductService
{
    public void Add(Product product) => productDal.Add(product);

    public void Delete(int id)
    {
        var prod = productDal.Get(c => c.ProductId == id);
        productDal.Delete(prod);
    }

    public List<Product> GetAll()
    {
        return productDal.GetList();
    }

    public List<Product> GetAllByCategory(int categoryId = 0) =>
        [.. productDal.GetList().Where(c => c.CategoryId == categoryId || categoryId == 0)];

    public Product GetById(int id)
    {
        return productDal.Get(p => p.ProductId == id);
    }

    public void Update(Product product) => productDal.Update(product);
}
