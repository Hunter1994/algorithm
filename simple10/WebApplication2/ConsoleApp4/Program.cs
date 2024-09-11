var outer = Task.Factory.StartNew(() =>
{
    Console.WriteLine("Outer task beginning.");

    var child = Task.Factory.StartNew(async () =>
    {
        //线程会在此处执行自旋等待，大约执行 500 万次循环
        Thread.SpinWait(5000000);
        Console.WriteLine("Detached task completed.");
    },TaskCreationOptions.AttachedToParent);

});

outer.Wait();
Console.WriteLine("Outer task completed.");

Console.ReadLine();