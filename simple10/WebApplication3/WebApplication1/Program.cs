using Consul;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ServiceDiscoveryClient>();
builder.Services.AddHealthChecks();
builder.Services.AddSingleton<IConsulClient, ConsulClient>(provider =>
       new ConsulClient(config =>
       {
           config.Address = new Uri("http://localhost:8500");
       }));


var app = builder.Build();

var consulClient= app.Services.GetService<IConsulClient>();
// Register service
var registration = new AgentServiceRegistration
{
    ID = "my-service-id2",
    Name = "my-service",
    Address = "localhost",
    Port = 7222,
    Tags = new[] { "api" },
    Checks = new[]
    {
            new AgentServiceCheck{
                HTTP = "http://localhost:7222/health",
            Interval = TimeSpan.FromSeconds(10),
            Timeout = TimeSpan.FromSeconds(1)
            }
    }
};
consulClient.Agent.ServiceRegister(registration).Wait();
// Handle application shutdown
app.Lifetime.ApplicationStopping.Register(() =>
{
    consulClient.Agent.ServiceDeregister("my-service-id").Wait();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHealthChecks("/health");

app.MapControllers();

app.Run();
