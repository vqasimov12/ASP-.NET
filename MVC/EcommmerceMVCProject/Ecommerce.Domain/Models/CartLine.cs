using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Models;

public class CartLine
{
    public Product Product { get; set; }
    public int Quantity {  get; set; }
}