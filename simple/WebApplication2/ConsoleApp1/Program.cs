// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.AspNetCore;
using System.Reflection;
using ConsoleApp1;
using ConsoleApp1.Controllers;


var builder = WebApplication.CreateBuilder(args);
//builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());
var aaa = builder.Configuration["Movies:ServiceApiKey"];
var aa1a = builder.Configuration["AllowedHosts"];
Console.WriteLine(aaa);
Console.WriteLine(aa1a);

builder.Services.AddTransient<IStartupFilter, DemoStartUpFileter>();
builder.Services.AddTransient<IStartupFilter, DemoStartUpFileter1>();

builder.Services.AddKeyedTransient<ICache, BigCache>("big");
builder.Services.AddKeyedTransient<ICache, SmallCache>("small");
var abj= ActivatorUtilities.CreateInstance(builder.Services.BuildServiceProvider(),typeof(SmallCache));
var aa= (abj as SmallCache).Get("aaa");


// 注册一个作用域服务
builder.Services.AddScoped<IScopedService, ScopedService>();

// 注册一个单例服务，但错误地将作用域服务注入到单例服务中
builder.Services.AddTransient<ISingletonService, SingletonService>();
builder.Services.AddControllers();

// 构建服务提供程序
var serviceProvider = builder.Services.BuildServiceProvider(new ServiceProviderOptions { ValidateScopes = true });

var aaaaa = serviceProvider.GetService<ISingletonService>().Get();


var app = builder.Build();


app.MapGet("/big", ([FromKeyedServices("big")]ICache cache) => cache.Get("big"));
app.MapGet("/small", ([FromKeyedServices("small")] ICache cache) => cache.Get("small"));

app.Map("/", async context => {
    Console.WriteLine("1111");
    await context.Response.WriteAsync("1111");
});
app.MapControllers();
app.Run();

public interface IScopedService {
    string Get();
}
public class ScopedService : IScopedService
{
    public string Get()
    {
        return "ScopedService";
    }
}

public interface ISingletonService {
    string Get();
}
public class SingletonService : ISingletonService
{
    private IScopedService _scopedService;

    public SingletonService(IScopedService scopedService)
    {
        _scopedService = scopedService;
    }

    public string Get()
    {
        return "SingletonService-" + _scopedService.Get();
    }
}

public interface ICache
{
    string Get(string str);
}
public class BigCache : ICache
{
    public string Get(string str)
    {
        return $"BigCache-{str}";
    }
}
public class SmallCache : ICache
{
    public string Get(string str)
    {
        return $"SmallCache-{str}";
    }
}