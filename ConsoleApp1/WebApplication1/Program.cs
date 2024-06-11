using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.BearerToken; 
using WebApplication1;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WebApplication1DbContext>(options => {
    options.UseInMemoryDatabase("test");
});
builder.Services.AddDataProtection();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
//builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<WebApplication1DbContext>();
builder.Services.AddAuthentication(IdentityConstants.BearerScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => { 
}).AddEntityFrameworkStores<WebApplication1DbContext>();

var sp= builder.Services.BuildServiceProvider();
var aaa=await sp.GetService<UserManager<IdentityUser>>().
    CreateAsync(new IdentityUser() { UserName="123@qq.com"}, "1q2w3E~");
var aa=sp.GetService<IOptions<BearerTokenOptions>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.MapIdentityApi<IdentityUser>();
app.Run();
