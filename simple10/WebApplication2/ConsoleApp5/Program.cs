using System.Diagnostics;

PerformanceCounter performanceCounter = new()
{
    CategoryName = ".NET CLR Memory",
    CounterName = "Large Object Heap size",
    InstanceName = "ConsoleApp5"
};

Console.WriteLine(performanceCounter.NextValue());