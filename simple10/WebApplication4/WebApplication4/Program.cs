var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<a>();

var aa = builder.Services.BuildServiceProvider();
var c1= aa.CreateScope();
var aaa= c1.ServiceProvider.GetService<a>();

var c2= c1.ServiceProvider.CreateScope();
var aaa2 = c2.ServiceProvider.GetService<a>();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



public class a
{

    public a()
    {
        Console.WriteLine("a");
    } }
