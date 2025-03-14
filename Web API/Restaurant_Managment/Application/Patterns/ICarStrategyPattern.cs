namespace Application.Patterns;

public interface ICarStrategyPattern
{
    public Task<decimal> CalculateStandart(int carId);
    public Task<decimal> CalculateDiscount(int carId);
    public Task<decimal> CalculateVip(int carId);
    public Task<decimal> CalculatePremium(int carId);
}
