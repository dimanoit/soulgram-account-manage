using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Soulgram.AccountManage.Appliaction;

public static class ServiceInjector
{
    public static void AddApplication(this IServiceCollection serviceCollection)
    {
        var currentAssembly = Assembly.GetExecutingAssembly();
        serviceCollection.AddMediatR(currentAssembly);
    }
}