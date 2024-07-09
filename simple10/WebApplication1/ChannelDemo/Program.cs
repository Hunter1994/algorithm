using ChannelDemo;

QueueWoker queueWoker = new QueueWoker();

Task.Run(async () => {

    CancellationTokenSource tokenSource = new CancellationTokenSource();
    while (true)
    {
        var f = await queueWoker.Dequeue();
        f(tokenSource.Token);

    }
}
);

while ( true)
{
    var res = Console.ReadKey();
    if (res.Key == ConsoleKey.W)
        queueWoker.Queue(async t => Console.WriteLine("1"));
    Console.WriteLine();
}