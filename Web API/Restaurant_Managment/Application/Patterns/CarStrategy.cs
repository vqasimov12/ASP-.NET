using Common.Exceptions;
using Domain.Enums;

namespace Application.Patterns;

public class CarStrategy(ICarStrategyPattern carStrategy):ICarStrategy
{

    public async Task<decimal> Calculate(int carId, PriceType type)
    {
        switch (type)
        {
            case PriceType.Discount:
                return await carStrategy.CalculateDiscount(carId);
            case PriceType.Premium:
                return await carStrategy.CalculatePremium(carId);
            case PriceType.Vip:
                return await carStrategy.CalculateVip(carId);
            case PriceType.Standart:
                return await carStrategy.CalculateVip(carId);
            default:
                throw new BadRequestException("Invalid price type");
        }
    }

}
