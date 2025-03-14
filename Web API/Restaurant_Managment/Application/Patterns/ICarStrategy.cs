

using Domain.Enums;

namespace Application.Patterns;

public interface ICarStrategy
{
    Task<decimal> Calculate(int carId, PriceType type);
}
