

using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using StackExchange.Redis;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

ServiceCollection service = new ServiceCollection();
service.AddDataProtection()
    //.PersistKeysToStackExchangeRedis(() =>
    //{
        
    //}, new StackExchange.Redis.RedisKey("aaaaaa"))
    .PersistKeysToFileSystem(new DirectoryInfo("keys"))
    .ProtectKeysWithDpapi();



var sp = service.BuildServiceProvider();


var dataProtection = sp.GetService<IKeyManager>();


Console.WriteLine();





//var dataProtection = sp.GetService<IDataProtectionProvider>().CreateProtector("ConsoleApp3");

////sp.GetService<IKeyManager>().RevokeKey(new Guid("2c0c6c49-4354-4154-9dcb-f89a6fed6963"));


////var a = dataProtection.Protect(Encoding.UTF8.GetBytes("a1234"));
////Console.WriteLine(Convert.ToBase64String(a));



//var ss = Convert.FromBase64String("CfDJ8ElsDCxUQ1RBncv4mm/taWNRhj/XGUOsSNB20jkdX2wf9vjSAMQAfbVXXXkZKVMRRzl+cuIF7LC4MnB8279cdxFa/+x3whlzVs8+XGlPnaeH3zFBgAClhE9QNyxyKCm1gg==");
//var d = dataProtection as IPersistedDataProtector;
//var aa = d.DangerousUnprotect(ss, true, out var q, out var w);
//Console.WriteLine(q);
//Console.WriteLine(w);
//Console.WriteLine(Encoding.UTF8.GetString(aa));
