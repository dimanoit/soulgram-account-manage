using Soulgram.AccountManage.Appliaction;
using Soulgram.AccountManage.Infrastracture;
using Soulgram.AccountManage.Infrastracture.IntegrationEvents.EventHandling;
using Soulgram.AccountManage.Infrastracture.IntegrationEvents.Events;
using Soulgram.AccountManage.Persistence;
using Soulgram.Eventbus.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddPersistence(configuration);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);


var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<SuccessedUserRegistrationEvent, SuccessedUserRegistrationEventHandler>();
eventBus.Subscribe<DeletedUserEvent, DeletedUserEventHandler>();

app.Run();