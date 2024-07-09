using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;
using WebApplication1;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => {
    options.ModelBinderProviders.Insert(0, new AuthorEntityBinderProvider());
}).AddJsonOptions(options => {
    options.JsonSerializerOptions.Converters.Add(new ObjectIdConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    await next();
});

app.UseHttpsRedirection();

var options = new RewriteOptions()
        .AddRedirect("Demo/get1", "Demo/get2")
       .AddRewrite(@"^Demo/get3/(\d+)", "Demo/get4?i=$1", skipRemainingRules: true);
app.UseRewriter(options);


app.UseAuthorization();

app.MapControllers();

app.Run();
