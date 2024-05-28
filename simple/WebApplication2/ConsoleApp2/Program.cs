// See https://aka.ms/new-console-template for more information
using Core.Comm;
var timestamp=SecurityHelper.GetTimeStamp();
var data = "hw_attendance_aliases,20240229060237717.json";
var sign= ValidSign(timestamp, data, "50000", "c89fb1a9b20a45aeb4fb771d664aa32c");

Console.WriteLine(sign + "   " + timestamp);

 string ValidSign(long timestamp, string data, string appid, string appSecret)
{
    SortedDictionary<string, string> sDic = new SortedDictionary<string, string>();
    sDic["appid"] = appid;
    sDic["timestamp"] = timestamp.ToString();
    sDic["data"] = data;
    string[] arrKeys = sDic.Keys.ToArray();
    string sign_pd = "";
    foreach (var k in arrKeys)
        sign_pd += k + "=" + sDic[k] + "&";
    sign_pd += "appsecret=" + appSecret;
    var signHash = SecurityHelper.GetSHA256hash(sign_pd.ToLower());
    return signHash;
}