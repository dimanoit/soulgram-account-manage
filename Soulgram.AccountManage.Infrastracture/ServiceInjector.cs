using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Soulgram.AccountManage.Application.Services;
using Soulgram.AccountManage.Infrastracture.HttpClients.OTTClient;
using Soulgram.AccountManage.Infrastracture.IntegrationEvents;
using Soulgram.Eventbus;
using Soulgram.Eventbus.Interfaces;
using Soulgram.EventBus.RabbitMq;
using Soulgram.File.Manager;
using Soulgram.File.Manager.Interfaces;
using Soulgram.File.Manager.Models;

namespace Soulgram.AccountManage.Infrastracture;

public static class ServiceInjector
{
    public static void AddInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddEventBus(configuration);
        serviceCollection.AddLocalFileManager(configuration);

        AddOttService(serviceCollection, configuration);
    }

    private static void AddOttService(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<OTTClientSettings>(options =>
            configuration.GetSection("OTTClientSettings").Bind(options));
        serviceCollection.AddHttpClient<OttClientService>();
        serviceCollection.AddScoped<IMovieSearchService, OttClientService>();
    }

    private static void AddLocalFileManager(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<LocalFileManagerOptions>(options =>
            configuration.GetSection("LocalFileManagerOptions").Bind(options));

        services.AddScoped<IFileManager, LocalFileManager>();
    }

    private static void AddEventBus(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var eventBusOption = configuration
            .GetSection("EventBus")
            .Get<EventBusOption>();

        RegisterEventHandlers(serviceCollection);

        serviceCollection.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
        serviceCollection.AddSingleton(_ => CreateRabbitMqConnection(eventBusOption));
        serviceCollection.AddSingleton<IEventBus, EventBus.RabbitMq.EventBus>(sp => CreateEventBus(sp, eventBusOption));
    }

    private static EventBus.RabbitMq.EventBus CreateEventBus(
        IServiceProvider sp,
        EventBusOption eventBusOption)
    {
        var rabbitMqConnection = sp.GetService<IRabbitMQConnection>();
        var busSubscriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();
        var eventBus = new EventBus.RabbitMq.EventBus(
            rabbitMqConnection,
            busSubscriptionsManager,
            sp,
            eventBusOption.Exchange,
            eventBusOption.Queue);

        return eventBus;
    }

    private static IRabbitMQConnection CreateRabbitMqConnection(
        EventBusOption eventBusOption)
    {
        var factory = new ConnectionFactory
        {
            HostName = eventBusOption.Url,
            DispatchConsumersAsync = true
        };

        if (!string.IsNullOrEmpty(eventBusOption.Username))
        {
            factory.UserName = eventBusOption.Username;
        }

        if (!string.IsNullOrEmpty(eventBusOption.Password))
        {
            factory.Password = eventBusOption.Password;
        }

        return new RabbitMQConnection(factory);
    }

    private static void RegisterEventHandlers(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<SuccessedUserRegistrationEventHandler>();
        serviceCollection.AddTransient<DeletedUserEventHandler>();
    }
}