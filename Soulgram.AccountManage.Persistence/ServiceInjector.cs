using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Soulgram.AccountManage.Persistence;

public static class ServiceInjector
{
    public static void AddPersistence(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AccountDbConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString));
        }

        //TODO temp fix, need to think about separete context for iventHandlers
        serviceCollection.AddDbContext<SoulgramContext>(_ => _.UseSqlServer(connectionString), ServiceLifetime.Transient, ServiceLifetime.Transient);
    }
}