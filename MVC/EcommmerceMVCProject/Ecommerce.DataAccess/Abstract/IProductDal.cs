using Ecommerce.Domain.Entities;
using Ecommerce.Repository.DataAccess;

namespace Ecommerce.DataAccess.Abstract;
public interface IProductDal : IEntityRepository<Product>
{

}
