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
        serviceCollection.AddDbContext<SoulgramContext>(
            options => options.UseSqlServer(connectionString));
    }
}