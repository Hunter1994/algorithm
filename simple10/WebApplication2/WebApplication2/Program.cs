using WebApplication2;
using Microsoft.Extensions.ObjectPool;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
builder.Services.AddSingleton<ObjectPool<RequestDto>>(serviceProvider => {
    var provider = serviceProvider.GetRequiredService<ObjectPoolProvider>();
    var policy = new DefaultPooledObjectPolicy<RequestDto>();
    return provider.Create(policy);
});


//builder.Services.AddStackExchangeRedisCache(options => {
//    options.Configuration = "192.168.1.59:6379,password=redis01:Hw191119,defaultDatabase=8";
//});
builder.Services.AddDistributedMemoryCache();

builder.Services.AddOutputCache(options => { 
    options.AddPolicy("Query", builder => builder.SetVaryByQuery("a"));
    
});

builder.Services.AddResponseCaching();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseResponseCaching();
app.UseOutputCache();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/cached", Gravatar.WriteGravatar).CacheOutput("Query");

app.Run();
