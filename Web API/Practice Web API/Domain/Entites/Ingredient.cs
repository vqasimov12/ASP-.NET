using Domain.BaseEntities;

namespace Domain.Entites;

public class Ingredient:ProductBase
{
    public int MinimumCount { get; set; }
    public int MaksimumCount { get; set; }
    public int FreeIngredientCount { get; set; }
    public List<int> DepartmentsId { get; set; }
}
