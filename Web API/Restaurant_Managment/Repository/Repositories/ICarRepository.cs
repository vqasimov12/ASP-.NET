using Domain.Entites;

namespace Repository.Repositories;

public interface ICarRepository
{
    Task AddCar(Car car);
    Task<Car> GetCarById(int carId);
    Task<IQueryable<Car>> GetAll();
}