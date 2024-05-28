using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebApplication3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using StackExchange.Redis;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.Features;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            using var host = await new HostBuilder().ConfigureWebHost(webBuilder =>
            {
                webBuilder.UseTestServer()
                .ConfigureServices(services => {
                    services.AddRateLimiter(options => {
                        options.AddPolicy<string, RedisRateLimiterPolicy>("user");
                    });
                    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
                    services.AddSingleton<IConnectionMultiplexer>(service => ConnectionMultiplexer.Connect("192.168.1.59:6379,password=redis01:Hw191119,defaultDatabase=8"));
                    services.AddAuthorization();
                    services.AddControllers();
                })
                .Configure(app => {
                    app.UseRouting();
                    app.UseAuthentication();
                    app.UseAuthorization();
                    app.UseRateLimiter();
                    app.UseEndpoints(build => {
                        build.MapControllers();
                        build.MapGet("/user", async context => {
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

                        build.MapGet("/", async context => await context.Response.WriteAsync("主页"))
                        .RequireRateLimiting("user")
                        .RequireAuthorization();

                    });
                });
            }).StartAsync();
            var token = (await host.GetTestClient().GetAsync("/user")).Content.ReadAsStringAsync().Result;

            var httpclient = host.GetTestClient();
            httpclient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
            var result = httpclient.GetAsync("/").Result.Content.ReadAsStringAsync().Result;
            var result2 = httpclient.GetAsync("/").Result.Content.ReadAsStringAsync().Result;
            Assert.Equal(result, "主页");
            Assert.Equal(result2, "操作频繁！");

        }
    }
}

