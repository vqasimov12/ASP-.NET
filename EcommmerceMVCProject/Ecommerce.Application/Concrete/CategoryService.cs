using Ecommerce.Application.Abstract;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Concrete;

public class CategoryServic(ICategoryDal categoryDal) : ICategoryService
{
    private readonly ICategoryDal _categoryDal = categoryDal;
    public List<Category> GetAll()
    {
        return _categoryDal.GetList();
    }
}
