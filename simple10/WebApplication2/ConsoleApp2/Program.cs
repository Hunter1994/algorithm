//int[] nums = Enumerable.Range(0, 1_000_000).ToArray();




//CancellationTokenSource cts = new CancellationTokenSource();
//ParallelOptions options = new ParallelOptions()
//{
//    CancellationToken = cts.Token,
//    //设置并行操作的最大并发度。Environment.ProcessorCount 返回当前计算机上的处理器核心数。
//    //这个设置告诉并行操作在执行时可以使用的最大线程或任务数
//    MaxDegreeOfParallelism = Environment.ProcessorCount 
//};

//cts.Cancel();

//try
//{
//    Parallel.ForEach(nums, options, i => Console.WriteLine(i));
//}
//catch (OperationCanceledException e)
//{
//    Console.WriteLine(e.Message);
//}
//finally {
//    cts.Dispose();
//}

// Source must be array or IList.
//using System.Collections.Concurrent;

//var source = Enumerable.Range(0, 100000).ToArray();

//// Partition the entire source array.
//var rangePartitioner = Partitioner.Create(0, source.Length);

//double[] results = new double[source.Length];

//// Loop over the partitions in parallel.
//Parallel.ForEach(rangePartitioner, (range, loopState) =>
//{
//    // Loop over each range element without a delegate invocation.
//    for (int i = range.Item1; i < range.Item2; i++)
//    {
//        results[i] = source[i] * Math.PI;
//    }
//});

//Console.WriteLine("Operation complete. Print results? y/n");
//char input = Console.ReadKey().KeyChar;
//if (input == 'y' || input == 'Y')
//{
//    foreach (double d in results)
//    {
//        Console.Write("{0} ", d);
//    }
//}





//long total = 0;
// Use type parameter to make subtotal a long, not an int
//Parallel.For<long>(0, nums.Length, () => 0,
//    (j, loop, subtotal) =>
//    {
//        subtotal += nums[j];
//        return subtotal;
//    },
//    subtotal => Interlocked.Add(ref total, subtotal));

//Console.WriteLine("nums.Length:" + nums.Length);

//Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
//{
//    subtotal += nums[j];
//    return subtotal;
//}, subtotal => {

//    Interlocked.Add(ref total, subtotal);
//    Console.WriteLine($"Processed subtotal: {subtotal}");
//});

//Console.WriteLine("The total is {0:N0}", total);
//Console.WriteLine("Press any key to exit");
//Console.ReadKey();


await Task.Factory.StartNew(async () =>
{
    Console.WriteLine("1");
}).ContinueWith(t =>
{
    Console.WriteLine(t.Status);
    if (t.Status == TaskStatus.RanToCompletion)
    {
        Console.WriteLine("2");
    }
    else
    {
        Console.WriteLine("3");
    }
});

Console.ReadLine();