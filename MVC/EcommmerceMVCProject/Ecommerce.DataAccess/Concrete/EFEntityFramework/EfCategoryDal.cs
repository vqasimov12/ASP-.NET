using Ecommerce.DataAccess.Abstract;
using Ecommerce.DataAccess.Context;
using Ecommerce.Domain.Entities;
using Ecommerce.Repository.DataAccess.EntityFrameworkAccess;

namespace Ecommerce.DataAccess.Concrete.EFEntityFramework;
public class EfCategoryDal:EFEntityRepositoryBase<Category,NortWindDbContext>,ICategoryDal
{

}