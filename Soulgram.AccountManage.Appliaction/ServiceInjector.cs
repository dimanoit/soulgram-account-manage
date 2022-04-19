using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Soulgram.AccountManage.Appliaction.Commands;

namespace Soulgram.AccountManage.Appliaction;

public static class ServiceInjector
{
    public static void AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);
    }
}