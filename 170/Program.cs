
using System.Globalization;

double repeatRate = 0;

if (!double.TryParse("0.1", NumberStyles.Any, CultureInfo.InvariantCulture, out repeatRate))
{


}

Console.WriteLine(repeatRate);