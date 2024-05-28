using Autofac.Extensions.DependencyInjection;
using WebApplication1;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebApplication1ContextConnection") ?? throw new InvalidOperationException("Connection string 'WebApplication1ContextConnection' not found.");

builder.Services.AddDbContext<WebApplication1Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebApplication1Context>();
builder.Services.AddAutofac();
builder.Services.ReplaceConfiguration(builder.Configuration);
builder.Services.AddApplication<DemoModule>();

var app=builder.Build();
app.InitializeApplication();
app.Run();

