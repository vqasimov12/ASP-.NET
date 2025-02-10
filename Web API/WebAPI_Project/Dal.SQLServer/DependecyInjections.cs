using Dal.SQLServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dal.SQLServer;

public static class DependecyInjections
{
    public static IServiceCollection AddSQLServerServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
        return services;
    }
}
