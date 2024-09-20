using Consul;
using WebApplication2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddScoped<ServiceDiscoveryClient>();
builder.Services.AddSingleton<IConsulClient, ConsulClient>(provider =>
       new ConsulClient(config =>
       {
           config.Address = new Uri("http://localhost:8500");
       }));

var app = builder.Build();
var consulClient = app.Services.GetService<IConsulClient>();
// Register service
var registration = new AgentServiceRegistration
{
    ID = "my-service-id2",
    Name = "my-service2",
    Address = "localhost",
    Port = 7009,
    Tags = new[] { "api" },
    Checks = new[]
    {
            new AgentServiceCheck{
                HTTP = "https://localhost:7009/health",
            Interval = TimeSpan.FromSeconds(10),
            Timeout = TimeSpan.FromSeconds(1)
            }
    }
};
consulClient.Agent.ServiceRegister(registration).Wait();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHealthChecks("/health");
app.UseAuthorization();

app.MapControllers();

app.Run();
