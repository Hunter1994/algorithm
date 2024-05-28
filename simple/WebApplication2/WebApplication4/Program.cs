using WebApplication4;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<RequestTimeLogger>();
builder.Services.AddResponseCaching();
builder.Services.AddRequestDecompression();
builder.Services.AddSingleton<FactoryActivatedMiddleware>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => { 
    });
    app.UseSwaggerUI(options => {
    });
}

app.UseHttpsRedirection();

app.UseRequestDecompression();
app.UseAuthorization();

app.UseResponseCaching();

app.MapControllers();

app.UseConventionalMiddleware();
app.UseFactoryActivatedMiddleware();


app.Run();
