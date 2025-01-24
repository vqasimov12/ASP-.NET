using Ecommerce.Domain.Abstracts;

namespace Ecommerce.Domain.Entities;

public class Product:IEntity
{
    public required int ProductID { get; set; }
    public required string ProductName { get; set; }
    public required int CategoryID {  get; set; }    
    public required decimal UnitPrice {  get; set; }
    public required short UnitInStock {  get; set; }
}
