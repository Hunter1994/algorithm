CancellationTokenSource ct=new CancellationTokenSource ();
ct.Cancel();
SpinWait.SpinUntil(() => ct.IsCancellationRequested,
          100000000);

Console.WriteLine();