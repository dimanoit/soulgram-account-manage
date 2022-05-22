using Serilog;
using Soulgram.AccountManage.Application;
using Soulgram.AccountManage.Infrastracture;
using Soulgram.AccountManage.Infrastracture.IntegrationEvents;
using Soulgram.AccountManage.Persistence;
using Soulgram.Eventbus.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host
    .ConfigureLogging((_, logging) => logging.ClearProviders())
    .UseSerilog();

var configuration = builder.Configuration;

builder.Services.AddPersistence(configuration);
builder.Services.AddInfrastructure(configuration);
builder.Services.AddControllers();
builder.Services.AddApplication(configuration);

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<SuccessedUserRegistrationEvent, SuccessedUserRegistrationEventHandler>();
eventBus.Subscribe<DeletedUserEvent, DeletedUserEventHandler>();

app.Run();