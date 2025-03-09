using Domain.Entites;

namespace Repository.Repositories;

public interface IRefreshTokenRepository
{
    Task<RefreshToken> GetStoredRefreshToken(string refreshToken);

    Task SaveRefreshToken(RefreshToken refreshToken);
}
