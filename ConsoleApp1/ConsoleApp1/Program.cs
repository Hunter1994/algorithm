using System;
using ConsoleApp1;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;



//Pbkdf2Demo pbkdf2Demo=new Pbkdf2Demo();
//pbkdf2Demo.Run();
//pbkdf2Demo.Run();
//pbkdf2Demo.Run();
//pbkdf2Demo.Run();

PersistedDataProtector timeLimitedDataProtector = new();
timeLimitedDataProtector.a();



//IServiceCollection services = new ServiceCollection();
//services.AddDataProtection();
////services.AddDbContext<DemoDbContext>(options =>
////{
////    options.UseSqlite("DataSource=D:\\src\\simple\\WebApplication5\\WebApplication3\\demo.db");
////});

//// Register XmlRepository for data protection.
//services.AddOptions<KeyManagementOptions>()
//.Configure<IServiceScopeFactory>((options, factory) =>
//{
//    options.XmlRepository = new CustomXmlRepository(factory);
//});
//services.AddSingleton<Class1>();

//var sp = services.BuildServiceProvider();

//while (true)
//    sp.GetService<Class1>().RunSample();