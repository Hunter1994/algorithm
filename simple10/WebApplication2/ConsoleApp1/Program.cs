
//Task tt = new Task(() => {
//    Console.WriteLine("111");
//});
using System;




var aa = new Progress<long>(percent =>
{
    Console.WriteLine($"Progress: {percent}%");
});
aa.ProgressChanged += Aa_ProgressChanged;

void Aa_ProgressChanged(object? sender, long e)
{
    Console.WriteLine("变化了" + e);
}

await ExecuteAsync(aa);



CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
var cancellationToken= cancellationTokenSource.Token;
cancellationTokenSource.Cancel();

var tt = Task.Run(async () =>
{
    await Task.Delay(1000);
    cancellationToken.ThrowIfCancellationRequested();
    Console.WriteLine("111");
}, cancellationToken);

Console.WriteLine(tt.Status);
await Task.Delay(1100);
Console.WriteLine(tt.Status);

Console.ReadLine();


async Task ExecuteAsync(IProgress<long> progress)
{
    for (global::System.Int32 i = 0; i < 10; i++)
    {
        progress.Report(i);
    }
}

public class ExecuteProgress : IProgress<long>
{
    public void Report(long value)
    {
        Console.WriteLine(value);
    }
}
