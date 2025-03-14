using Repository.Common;

namespace Application.Patterns;

public class CarStrategyPattern(IUnitOfWork unitOfWork) : ICarStrategyPattern
{
    public async Task<decimal> CalculateDiscount(int carId)
    {
        var car = await unitOfWork.CarRepository.GetCarById(carId);
        return car.IntitialPrice * (decimal)0.8;
    }

    public async Task<decimal> CalculatePremium(int carId)
    {
        var car = await unitOfWork.CarRepository.GetCarById(carId);
        return car.IntitialPrice * (decimal)1.2;
    }

    public async Task<decimal> CalculateStandart(int carId)
    {
        var car = await unitOfWork.CarRepository.GetCarById(carId);
        return car.IntitialPrice;
    }

    public async Task<decimal> CalculateVip(int carId)
    {
        var car = await unitOfWork.CarRepository.GetCarById(carId);
        return car.IntitialPrice * (decimal)1.4;
    }
}
