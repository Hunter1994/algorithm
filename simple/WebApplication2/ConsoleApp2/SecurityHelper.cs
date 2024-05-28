using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Comm
{
   public class SecurityHelper
    {
        /// <summary>
        /// 加密解密错误返回
        /// </summary>
        public const string Error = "error";
        /// <summary>
        /// 密码强度验证
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool VerifyUserPasswordStrength(string pwd)
        {
            if (pwd == null) return false;
            if (pwd.Length < 8 || pwd.Length > 20) return false;
            if (pwd.Contains("123456")) return false;

            var zm_big = Regex.IsMatch(pwd, "(?=.*[A-Z])") ? 1 : 0;
            var zm_small = Regex.IsMatch(pwd, "(?=.*[a-z])") ? 1 : 0;
            var shuzi = Regex.IsMatch(pwd, "(?=.*\\d)") ? 1 : 0;
            var zifu = Regex.IsMatch(pwd, "(?=.*[\\[\\]\\^\\-_*×――(^)$%~!＠@＃#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;/\'\"{}（）‘’“”-【】])") ? 1 : 0;

            return (zm_big + zm_small + shuzi + zifu) >= 3;
        }

        public static string MD5Hash(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(str));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }

        /// <summary>
        /// 字母数字字符 两种方式组合
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool PasswordStrengthValid(string password)
        {
            int iNum = 0, iLtt = 0, iSym = 0;
            foreach (char c in password)
            {
                if (c >= '0' && c <= '9') iNum++;
                else if (c >= 'a' && c <= 'z') iLtt++;
                else if (c >= 'A' && c <= 'Z') iLtt++;
                else iSym++;
            }
            if (iLtt == 0 && iSym == 0) return false; //纯数字密码
            if (iNum == 0 && iLtt == 0) return false; //纯符号密码
            if (iNum == 0 && iSym == 0) return false; //纯字母密码
            if (password.Length < 6) return false;//长度不大于6的密码
            if (iLtt == 0) return true; //数字和符号构成的密码
            if (iSym == 0) return true; //数字和字母构成的密码
            if (iNum == 0) return true; //字母和符号构成的密码
            if (iLtt != 0 && iSym != 0 && iNum != 0) return true;//字母和符号和数字构成的密码
            return false;
        }

        public static bool SpecialCharacters(string str)
        {
            if (string.IsNullOrEmpty(str)) return true;
            var specialCharacters = "!@#$%^&*()_+|}{\":>?< ,，~ ！";
            foreach (var item in str)
            {
                if (specialCharacters.Contains(item)) return true;
            }
            return false;
        }


        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="encryptedText">密文字符串</param>
        /// <param name="strKey">密钥</param>
        /// <param name="mode">加密模式</param>
        /// <param name="padding">填充模式</param>
        /// <returns>返回解密后的字符串</returns>
        public static string DecryptAes(string encryptedText, string strKey, CipherMode mode = CipherMode.CBC,
            PaddingMode padding = PaddingMode.PKCS7)
        {
            if (string.IsNullOrEmpty(encryptedText)) return string.Empty;

            if (string.IsNullOrEmpty(strKey))
                throw new ArgumentException("Key is null.");
            try
            {
                var key = Encoding.UTF8.GetBytes(strKey);
                var ivValue = GetIVValueByKey(key);
                using (var rijndaelManaged = new RijndaelManaged
                {
                    Key = key,
                    IV = ivValue,
                    KeySize = 256,
                    BlockSize = 128,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                })
                {
                    using (var transform = rijndaelManaged.CreateDecryptor(key, ivValue))
                    {
                        var inputBytes = Convert.FromBase64String(encryptedText);
                        var encryptedBytes = transform.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                        return Encoding.UTF8.GetString(encryptedBytes);
                    }
                }
            }
            catch (Exception ex)
            {

                return Error;
            }

        }

        /// <summary>
        /// 通过Key获取对称算法的初始化向量, 取Key的前16位
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static byte[] GetIVValueByKey(byte[] key)
        {
            if (key.Length < 16)
                throw new ArgumentException("无法从Key中获取偏移量!");
            return key.Take(16).ToArray();
        }

        /// <summary>
        /// Sha256签名
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetSHA256hash(string input)
        {
            byte[] clearBytes = Encoding.UTF8.GetBytes(input);
            SHA256 sha256 = new SHA256Managed();
            sha256.ComputeHash(clearBytes);
            byte[] hashedBytes = sha256.Hash;
            sha256.Clear();
            string output = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return output;
        }

        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // 定义其实时间
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="strKey"></param>
        /// <param name="mode">加密模式</param>
        /// <param name="padding">填充模式</param>
        /// <returns></returns>
        public static string EncryptAes(string plainText, string strKey, CipherMode mode = CipherMode.CBC,
            PaddingMode padding = PaddingMode.PKCS7)
        {
            if (string.IsNullOrEmpty(plainText)) return string.Empty;

            if (string.IsNullOrEmpty(strKey))
                throw new ArgumentException("Key is null.");
            try
            {
                var key = Encoding.UTF8.GetBytes(strKey);
                var ivValue = GetIVValueByKey(key);
                using (var rijndaelManaged = new RijndaelManaged
                {
                    Key = key, // 密钥，长度可为128， 196，256比特位
                    IV = ivValue, //初始化向量(Initialization vector), 用于CBC模式初始化
                    KeySize = 256, //接受的密钥长度
                    BlockSize = 128, //加密时的块大小，应该与iv长度相同
                    Mode = CipherMode.CBC, //加密模式
                    Padding = PaddingMode.PKCS7 //填白模式，对于AES, C# 框架中的 PKCS　＃７等同与Java框架中 PKCS #5
                })
                {
                    using (var transform = rijndaelManaged.CreateEncryptor(key, ivValue))
                    {
                        var inputBytes = Encoding.UTF8.GetBytes(plainText); //字节编码， 将有特等含义的字符串转化为字节流
                        var encryptedBytes = transform.TransformFinalBlock(inputBytes, 0, inputBytes.Length); //加密
                        return Convert.ToBase64String(encryptedBytes); //将加密后的字节流转化为字符串，以便网络传输与储存。
                    }
                }
            }
            catch (Exception ex)
            {

                return string.Empty;
            }

        }
    }
}
