using Autofac.Core;
using DemoApplication;
using DemoApplicationContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Conventions;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace WebApplication1
{
    [DependsOn(typeof(DemoApplicationModule),
                typeof(AbpAutofacModule),
                typeof(AbpSwashbuckleModule),
                typeof(AbpAspNetCoreMvcModule)
        )]
    public class WebApplication1Module:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            Configure<AbpAspNetCoreMvcOptions>(options => {
                options.ConventionalControllers.Create(typeof(DemoApplicationModule).Assembly, options => {
                    options.UseV3UrlStyle = true;
                });
            });


            context.Services.AddAuthentication("customer")
                .AddScheme<CustomerAuthenticationHanderOptions, CustomerAuthenticationHander>("customer", options => { })
                .AddScheme<OAuthOptions, DemoAuthenticationHander>("oauth", options => { 
                    options.CallbackPath = "";
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
            context.Services.AddAuthorization();

            context.Services.AddHttpContextAccessor();
            context.Services.AddAbpSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            }
        );


        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API");
            });

            app.UseConfiguredEndpoints();

        }


    }
}
