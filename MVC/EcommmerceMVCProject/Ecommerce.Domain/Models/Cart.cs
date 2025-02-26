namespace Ecommerce.Domain.Models;

public class Cart
{
    public List<CartLine> CartLines { get; set; }
    public decimal Total
    {
        get => CartLines.Sum(c => (c.Product.UnitPrice ?? 0) * c.Quantity);
    }

    public Cart()
    {
        CartLines = [];
    }

}