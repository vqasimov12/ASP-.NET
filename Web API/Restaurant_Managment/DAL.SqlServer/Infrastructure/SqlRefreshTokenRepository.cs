using DAL.SqlServer.Context;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlRefreshTokenRepository(AppDbContext context) : IRefreshTokenRepository
{
    public async Task<RefreshToken> GetStoredRefreshToken(string refreshToken) =>
        await context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken);

    public async Task SaveRefreshToken(RefreshToken refreshToken) =>
        await context.RefreshTokens.AddAsync(refreshToken);
}