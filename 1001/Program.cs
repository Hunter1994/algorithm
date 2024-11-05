using Newtonsoft.Json;


decimal? a = null ;

var aa= JsonConvert.SerializeObject(a);

var sss = $"aa={a}";
Console.WriteLine(sss);




public class A
{ 
    public string Id { get; set; }
}