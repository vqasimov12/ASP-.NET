using Ecommerce.Domain.Abstracts;

namespace Ecommerce.Domain.Entities;

public class Category:IEntity
{
    public int CategoryID { get; set; }
    public required string CategoryName { get; set; }
}
