using Domain.BaseEntities;

namespace Domain.Entites;

public class Product:ProductBase
{
    public List<int> IngredientsId { get; set; }
    public List<int> DepartmentsId { get; set; }
    public List<int> AllergenGroupId { get; set; }
}
