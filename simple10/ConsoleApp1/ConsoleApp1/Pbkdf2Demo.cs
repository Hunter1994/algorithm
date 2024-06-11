using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Pbkdf2Demo
    {
        public void Run()
        {
            string? password = "a123456";

            //使用加密强随机字节序列生成128位salt。
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // 除以8将位转换为字节
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            //导出一个256位的子密钥（使用HMACSHA256进行100000次迭代）
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            Console.WriteLine($"Hashed: {hashed}");

        }
    }
}
