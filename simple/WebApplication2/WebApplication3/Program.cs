using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.Configure<MyConfigOptions>(builder.Configuration.GetSection(
//                                        MyConfigOptions.MyConfig));
builder.Services.AddOptions<MyConfigOptions>().Bind(builder.Configuration.GetSection(
                                        MyConfigOptions.MyConfig)).ValidateOnStart() ;
builder.Services.AddSingleton<IValidateOptions
                              <MyConfigOptions>, MyConfigValidation>();




builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false, // 是否验证颁发者
            ValidateAudience = false, // 是否验证受众者
            ValidateLifetime = true, // 是否验证token有效期
            ValidateIssuerSigningKey = true, // 是否验证密钥
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDI2a2EJ7m872v0afyoSDJT2o1+SitIeJSWtLJU8/Wz2m7gStexajkeD+Lka6DSTy8gt9UwfgVQo6uKjVLG5Ex7PiGOODVqAEghBuS7JzIYU5RvI543nNDAPfnJsas96mSA7L/mD7RTE2drj6hf3oZjJpMPZUQI/B1Qjb5H3K3PNwIDAQAB")) // 设置密钥
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddSingleton<IConnectionMultiplexer>(service => ConnectionMultiplexer.Connect("192.168.1.59:6379,password=redis01:Hw191119,defaultDatabase=8"));

builder.Services.AddRateLimiter(options => {
    options.AddPolicy<string, RedisRateLimiterPolicy>("user");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

app.UseRateLimiter();

app.MapGet("/user", async (context) => {

    Random random = new Random();
    var a = random.Next(0, 100);
    var claims = new List<Claim>()
           {
                new Claim(ClaimTypes.Name,"admin"+a),
                new Claim(ClaimTypes.Role,"admin")
    };
    //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Const.SecurityKey));
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDI2a2EJ7m872v0afyoSDJT2o1+SitIeJSWtLJU8/Wz2m7gStexajkeD+Lka6DSTy8gt9UwfgVQo6uKjVLG5Ex7PiGOODVqAEghBuS7JzIYU5RvI543nNDAPfnJsas96mSA7L/mD7RTE2drj6hf3oZjJpMPZUQI/B1Qjb5H3K3PNwIDAQAB"));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        issuer: "https://localhost:44355",
        audience: "Ousu_Xld_Platform",
        claims: claims,
        expires: DateTime.Now.AddDays(300),
        signingCredentials: creds);
    var str = new JwtSecurityTokenHandler().WriteToken(token);
    await context.Response.WriteAsync(str);
});

app.MapControllers();

app.Run();
