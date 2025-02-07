using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Abstract;

public interface ICategoryService
{
    List<Category>GetAll();
}
