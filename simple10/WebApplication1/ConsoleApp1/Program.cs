
using System;
using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

//var manifestEmbeddedProvider =
//    new ManifestEmbeddedFileProvider(typeof(Program).Assembly);
//var aaa=manifestEmbeddedProvider.GetFileInfo(string.Empty);

ServiceCollection services = new ServiceCollection();
var aaa = new CompositeFileProvider(
    new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory + "files"),
    new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory + "files2"),
    new ManifestEmbeddedFileProvider(typeof(Program).Assembly)
    );
services.AddSingleton<IFileProvider>(aaa);

var sp = services.BuildServiceProvider();
var fileProvider = sp.GetService<IFileProvider>();


var changeToken1 = fileProvider.Watch("1.txt");
ChangeToken.OnChange(() => changeToken1, () => {
    Console.WriteLine("文件发生变更");
});
Console.ReadLine();
//while (true)
//{
//    var changeToken = fileProvider.Watch("1.txt");
//    var tcs = new TaskCompletionSource<object>();
//    changeToken.RegisterChangeCallback(obj => { 
//        ((TaskCompletionSource<object>)obj).SetResult(null);
//        Console.WriteLine("文件发送变更");
//    }, tcs);

//    await tcs.Task.ConfigureAwait(false);
//}




////services.AddSingleton<IFileProvider>(new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory + "files"));
////services.AddSingleton<IFileProvider>(new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory + "files2"));
////services.AddSingleton<IFileProvider>(new ManifestEmbeddedFileProvider(typeof(Program).Assembly));

//var sp = services.BuildServiceProvider();
////var aaa = sp.GetServices<IFileProvider>();
////foreach (var item in aaa)
////{
////    var aaaa=item.GetDirectoryContents(string.Empty);
////    foreach (var file in aaaa)
////    {
////        Console.WriteLine(file.Name);
////    }

////}

//var fileProvider= sp.GetService<IFileProvider>();

//var aa = fileProvider.GetFileInfo("1.txt");
//Console.WriteLine(aa.Name);
//var aa1 = fileProvider.GetFileInfo("2.txt");
//Console.WriteLine(aa1.Name);
//var aa2 = fileProvider.GetFileInfo("files3/123.txt");
//Console.WriteLine(aa2.Name);

// var token = fileProvider.Watch("1.txt");

////var tcs = new TaskCompletionSource<object>();

////Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

////token.RegisterChangeCallback(state => {
////    ((TaskCompletionSource<object>)state).TrySetResult(null);
////    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
////}
////, tcs);

////await tcs.Task.ConfigureAwait(true);
////Console.WriteLine(Thread.CurrentThread.ManagedThreadId);








//string str = "123\n456\n";

//var buffer = new ReadOnlySequence<char>(str.ToArray());

//while (true)
//{
//    if (buffer.Length == 0) break;

//    var position = buffer.PositionOf('\n');//找到\n位置

//    ReadOnlySequence<char> readonlyseqence;
//    if (position != null)
//    {
//        readonlyseqence = buffer.Slice(0, position.Value);
//        buffer = buffer.Slice(buffer.GetPosition(1, position.Value));//从\n位置后一个位置开始
//    }
//    else
//    {
//        readonlyseqence = buffer;
//    }


//    foreach (var segment in readonlyseqence)
//    {
//        Console.WriteLine(segment);
//    }

//}





//using System;
//using System.Buffers;
//using System.ComponentModel.DataAnnotations;
//using System.Text;

//string str = "123\n456";

//byte[] data = Encoding.UTF8.GetBytes(str);


//var sequence = new ReadOnlySequence<byte>(data);
//long totallength = sequence.Length;

//SequencePosition? postion = null;

//do
//{
//    postion = sequence.PositionOf<byte>((byte)'\n');

//    if (postion != null)
//    {
//        foreach (ReadOnlyMemory<byte> segment in sequence.Slice(0, postion.Value))
//        {
//            foreach (byte b in segment.Span)
//            {
//                Console.WriteLine(Encoding.UTF8.GetString([b]));
//            }
//        }

//        var aaa = sequence.GetPosition(0, postion.Value);
//        sequence = sequence.Slice(sequence.GetPosition(1, postion.Value));
//    }

//} while (postion != null);

//Console.WriteLine();
//Console.WriteLine(totallength);
//Console.WriteLine(sequence.Length);
