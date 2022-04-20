using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Soulgram.AccountManage.Application.Commands;

namespace Soulgram.AccountManage.Application;

public static class ServiceInjector
{
    public static void AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);
    }
}