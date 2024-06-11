using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PersistedDataProtector
    {
        public void RunSample()
        {
            var _protector = DataProtectionProvider.Create(new DirectoryInfo(@"d:/Keys"), options => {
                options.ProtectKeysWithDpapi();
            });
            var baseProtector = _protector.CreateProtector("Contoso.MyClass.v1");

            byte[] input = Encoding.UTF8.GetBytes("123456");
            var protectedData = baseProtector.Protect(input);

            //string protectedPayload = baseProtector.Protect(input);
            //Console.WriteLine($"Protect returned: {protectedPayload}");

            //string unprotectedPayload = baseProtector.Unprotect(protectedPayload);

            IPersistedDataProtector persistedProtector = baseProtector as IPersistedDataProtector;
            if (persistedProtector == null)
            {
                throw new Exception("Can't call DangerousUnprotect.");
            }
            bool requiresMigration, wasRevoked;

            var unprotectedPayload = persistedProtector.DangerousUnprotect(
                protectedData: Encoding.UTF8.GetBytes("CfDJ8FtdAN06XdpOrgONIWJqYbPkIOavBB0EZ4xhL7Ba3fb5FDxlzO6HK9Dtrtb28r3XJZKfl9ce-zoqxAVhRzhb3uKY_opFZ9p5I6OaoS0toMC2DMcCRJKwV9Rl9coIlJAxZw"),
                ignoreRevocationErrors: true,
                requiresMigration: out requiresMigration,
                wasRevoked: out wasRevoked);

            //string unprotectedPayload = baseProtector.Unprotect("CfDJ8FtdAN06XdpOrgONIWJqYbPkIOavBB0EZ4xhL7Ba3fb5FDxlzO6HK9Dtrtb28r3XJZKfl9ce-zoqxAVhRzhb3uKY_opFZ9p5I6OaoS0toMC2DMcCRJKwV9Rl9coIlJAxZw");
            Console.WriteLine($"Unprotect returned: {unprotectedPayload}");

        }

        public void a()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataProtection()
                // point at a specific folder and use DPAPI to encrypt keys
                .PersistKeysToFileSystem(new DirectoryInfo(@"c:\temp-keys"))
                .ProtectKeysWithDpapi()
                .SetApplicationName("ConsoleApp1")
                .UseCustomCryptographicAlgorithms(new ManagedAuthenticatedEncryptorConfiguration
                {
                    // A type that subclasses SymmetricAlgorithm
                    EncryptionAlgorithmType = typeof(Aes),

                    // Specified in bits
                    EncryptionAlgorithmKeySize = 256,

                    // A type that subclasses KeyedHashAlgorithm
                    ValidationAlgorithmType = typeof(HMACSHA256)
                }); ;

            var services = serviceCollection.BuildServiceProvider();
            var discriminator =services.GetRequiredService<IOptions<DataProtectionOptions>>()
    .Value.ApplicationDiscriminator;
            // get a protector and perform a protect operation
            var protector = services.GetDataProtector("Sample.DangerousUnprotect");
            Console.Write("Input: ");
            byte[] input = Encoding.UTF8.GetBytes(Console.ReadLine());
            var protectedData = protector.Protect(input);
            Console.WriteLine($"Protected payload: {Convert.ToBase64String(protectedData)}");

            // demonstrate that the payload round-trips properly
            var roundTripped = protector.Unprotect(protectedData);
            Console.WriteLine($"Round-tripped payload: {Encoding.UTF8.GetString(roundTripped)}");

            // get a reference to the key manager and revoke all keys in the key ring
            var keyManager = services.GetService<IKeyManager>();
            Console.WriteLine("Revoking all keys in the key ring...");
            keyManager.RevokeAllKeys(DateTimeOffset.Now, "Sample revocation.");

            // try calling Protect - this should throw
            Console.WriteLine("Calling Unprotect...");
            Thread.Sleep(5000);
            try
            {
                var unprotectedPayload = protector.Unprotect(protectedData);
                Console.WriteLine($"Unprotected payload: {Encoding.UTF8.GetString(unprotectedPayload)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
            }

            // try calling DangerousUnprotect
            Console.WriteLine("Calling DangerousUnprotect...");
            try
            {
                IPersistedDataProtector persistedProtector = protector as IPersistedDataProtector;
                if (persistedProtector == null)
                {
                    throw new Exception("Can't call DangerousUnprotect.");
                }

                bool requiresMigration, wasRevoked;
                var unprotectedPayload = persistedProtector.DangerousUnprotect(
                    protectedData: protectedData,
                    ignoreRevocationErrors: true,
                    requiresMigration: out requiresMigration,
                    wasRevoked: out wasRevoked);
                Console.WriteLine($"Unprotected payload: {Encoding.UTF8.GetString(unprotectedPayload)}");
                Console.WriteLine($"Requires migration = {requiresMigration}, was revoked = {wasRevoked}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
            }
        }
    }
}
