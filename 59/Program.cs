// See https://aka.ms/new-console-template for more information
var a1 = Convert.ToDateTime("2023-10-14T14:00:00.000-04:00");
var a2 = Convert.ToDateTime("2023-10-14T14:00:00.000+08:00");
var a3 = Convert.ToDateTime("2023-10-14T14:00:00.000+09:00");
Console.WriteLine(a1);
Console.WriteLine(a2);
Console.WriteLine(a3);
Console.WriteLine(a1.ToUniversalTime());
Console.WriteLine(a2.ToUniversalTime());
Console.WriteLine(a3.ToUniversalTime());
