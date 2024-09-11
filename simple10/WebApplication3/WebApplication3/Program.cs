using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using WebApplication3;
using WebApplication3.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EFDbContext>(options => {
    options.UseMySql(builder.Configuration.GetConnectionString("Default"), new MySqlServerVersion("5.7.0"), options => options.UseNetTopologySuite());
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ITenantService, TenantService>(sp =>
{
    var tenantIdString = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.Request.Query["TenantId"];

    return new TenantService() { Tenant = tenantIdString };
});



//builder.Services.AddScoped<ITenantId>(sp =>
//{
//    var tenantIdString = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.Request.Query["TenantId"];

//    return tenantIdString != StringValues.Empty && int.TryParse(tenantIdString, out var tenantId)
//        ? new TenantId(tenantId)
//        : null;
//});

//builder.Services.AddScoped(
//    sp => sp.GetRequiredService<WeatherForecastScopedFactory>().CreateDbContext());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
