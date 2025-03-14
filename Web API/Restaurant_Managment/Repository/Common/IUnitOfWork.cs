﻿using Repository.Repositories;

namespace Repository.Common;

public interface IUnitOfWork
{
    public ICategoryRepository CategoryRepository { get;}
    public IUserRepository UserRepository { get;}
    public IProductRepository ProductRepository { get; }
    public ICustomerRepository CustomerRepository { get; }
    public IRefreshTokenRepository RefreshTokenRepository { get; }
    public ICarRepository CarRepository { get; }
    Task<int> SaveChanges();
}