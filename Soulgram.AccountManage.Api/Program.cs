using Soulgram.AccountManage.Application;
using Soulgram.AccountManage.Infrastracture;
using Soulgram.AccountManage.Infrastracture.IntegrationEvents.EventHandling;
using Soulgram.AccountManage.Infrastracture.IntegrationEvents.Events;
using Soulgram.AccountManage.Persistence;
using Soulgram.Eventbus.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddPersistence(configuration);
builder.Services.AddInfrastructure(configuration);
builder.Services.AddControllers();
builder.Services.AddApplication();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<SuccessedUserRegistrationEvent, SuccessedUserRegistrationEventHandler>();
eventBus.Subscribe<DeletedUserEvent, DeletedUserEventHandler>();

app.Run();