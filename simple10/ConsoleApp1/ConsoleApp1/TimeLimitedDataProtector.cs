using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TimeLimitedDataProtector
    {

        public void RunSample()
        {
            var _protector = DataProtectionProvider.Create("d:/Keys/");
            var baseProtector = _protector.CreateProtector("Contoso.MyClass.v1");

            var timeLimitedProtector = baseProtector.ToTimeLimitedDataProtector();

            Console.Write("Enter input: ");
            string input = Console.ReadLine();

            // protect the payload
            string protectedPayload = timeLimitedProtector.Protect(input, TimeSpan.FromSeconds(5));
            Console.WriteLine($"Protect returned: {protectedPayload}");

            // unprotect the payload
            string unprotectedPayload = timeLimitedProtector.Unprotect(protectedPayload);
            Console.WriteLine($"Unprotect returned: {unprotectedPayload}");

            Thread.Sleep(5000);
            // 失效
             unprotectedPayload = timeLimitedProtector.Unprotect(protectedPayload);
            Console.WriteLine($"Unprotect returned: {unprotectedPayload}");
        }

    }
}
