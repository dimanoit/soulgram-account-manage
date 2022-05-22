using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Soulgram.AccountManage.Application.Commands;
using Soulgram.AccountManage.Application.Services;
using Soulgram.Logging;
using Soulgram.Logging.Models;

namespace Soulgram.AccountManage.Application;

public static class ServiceInjector
{
    public static void AddApplication(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);
        serviceCollection.AddTransient<IMateService, MateService>();
    }

    private static IServiceCollection AddLogging(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var loggingSettings = configuration
            .GetSection("LoggingSettings")
            .Get<LoggingSettings>();

        return services.AddLogging(loggingSettings);
    }
}