using WebApplication1;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddHeaderPropagation(options => options.Headers.Add("X-TraceId"));
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();
//app.UseHeaderPropagation();
app.Run();
