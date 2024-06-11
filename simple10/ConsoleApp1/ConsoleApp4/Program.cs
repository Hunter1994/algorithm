 List<List<string>> memoryLeakList = new List<List<string>>();
//编写一段死循环代码用于演示内存泄漏的情况  
//每次迭代都会创建一个新的List<string>对象并将其添加到一个静态的List<List<string>>集合中，但却没有释放这些对象，从而导致内存泄漏  
while (true)
{
    var newList = new List<string>();
    for (int i = 0; i < 1000; i++)
    {
        var currentValue = i + " - " + Guid.NewGuid().ToString();
        Console.WriteLine(currentValue);
        newList.Add(currentValue);
    }
    memoryLeakList.Add(newList);
}