// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;

while (true)
{
    Console.WriteLine("请输入审核id[data_update_apply.id]：");
    var id = Console.ReadLine();
    var date = DateTime.Now;
    var timeSpan = GetTimeSpan();
    var appid = "ousu98657453";
    var appSecretKey = "EC29220BE47B4CAAB32F5273FA90AB3E";
    var md5 = Sign(timeSpan, appid, appSecretKey);
    var str = "{\"timeStamp\":" + timeSpan + ",\"data\":{\"auditUsername\":\"\",\"reason\":\"\",\"auditTime\":\"" + date.ToString("yyyy-MM-dd HH:mm:ss") + "\",\"id\":\"" + id + "\",\"auditName\":\"手动变更\",\"status\":2},\"appid\":\"ousu98657453\",\"sign\":\"" + md5 + "\"}";
    Console.WriteLine(str);
}


static string Sign(long timestamp, string appid, string appSecretKey)
{
    return MD5(($"{timestamp}&{appid}&{appSecretKey}").ToUpper());
}
/// <summary>
/// 根据时间获取Timespan
/// </summary>
/// <returns>返回int（13）长度</returns>
static long GetTimeSpan()
{
    TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);
    //得到精确到毫秒的时间戳（长度13位）
    long time = (long)ts.TotalMilliseconds;
    return time;
}
/// <summary>
/// Md5加密
/// </summary>
/// <param name="sourceStr"></param>
/// <param name="islowerCase"></param>
/// <returns></returns>
static string MD5(string sourceStr, bool islowerCase = true)
{
    if (string.IsNullOrEmpty(sourceStr)) return sourceStr;
    var md5 = new MD5CryptoServiceProvider();
    var b = md5.ComputeHash(Encoding.UTF8.GetBytes(sourceStr));
    string md5Str = "";
    foreach (var item in b)
    {
        var x = islowerCase ? "x2" : "X2";
        md5Str += item.ToString(x);
    }
    return md5Str;
}
