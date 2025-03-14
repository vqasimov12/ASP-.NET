using DAL.SqlServer.Context;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlCarRepository(AppDbContext context) : ICarRepository
{
    public async Task AddCar(Car car)
    {
        await context.Cars.AddAsync(car);
        await context.SaveChangesAsync();
    }

    public async Task<IQueryable<Car>> GetAll() =>
        context.Cars.AsQueryable();

    public async Task<Car> GetCarById(int carId) =>
        await context.Cars.FirstOrDefaultAsync(z => z.Id == carId);
}
