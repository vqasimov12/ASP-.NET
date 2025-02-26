using Ecommerce.Domain.Entities;

namespace Ecommerce.WebUI;

public class ProductAddViewModel
{
    public Product Product { get; set; }
    public List<Category> Categories { get; set; }
}