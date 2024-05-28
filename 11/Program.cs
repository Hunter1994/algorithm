// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var arr=new int[16]{0,33,27,21,16,13,15,19,5,6,7,8,1,2,12,0};
int current=14;



void insert(int data)
{
    ++current;
    arr[current]=data;
    var i=current;
    while(i/2>0&&arr[i/2]<arr[i])
    {
        var temp=arr[i/2];
        arr[i/2]=arr[i];
        arr[i]=temp;
        i=i/2;
    }
}
void DeleteRoot()
{
    arr[1]=arr[current];
    arr[current]=0;
    --current;
    var i=1;
    while(i*2<=current&&arr[i]<arr[i*2])
    {
        int maxPos=i;
        if(arr[i]<arr[i*2])maxPos=i*2;
        if(arr[maxPos]<arr[i*2+1])maxPos=i*2+1;
        var temp=arr[maxPos];
        arr[maxPos]=arr[i];
        arr[i]=temp;
        i=maxPos;
    }
}




var arr2=new int[]{0,7,5,19,8,4,1,20,13,16};
var n=arr2.Length-1;
var i= n/2;
for(;i>=1;--i)
{
    var j=i;
    while(true)
    {
        var maxpos=j;
        if(j*2<=n&&arr2[j]<arr2[j*2])maxpos=j*2;
        if(j*2+1<=n&&arr2[maxpos]<arr2[j*2+1])maxpos=j*2+1;
        if(maxpos==j)break;
        var temp=arr2[maxpos];
        arr2[maxpos]=arr2[j];
        arr2[j]=temp;
        j=maxpos;
    }
}
foreach(var item in arr2)
{
    Console.Write(item+" ");
}
Console.WriteLine();
Console.WriteLine("------------------");

var nn=n;
for(int k=n;k>1;k--)
{
    var temp=arr2[1];
    arr2[1]=arr2[nn];
    arr2[nn]=temp;
    --nn;
    var kk=1;
    while(true)
    {
        var maxpod=kk;
        if(kk*2<=nn&&arr2[kk]<arr2[kk*2])maxpod=kk*2;
        if(kk*2+1<=nn&&arr2[maxpod]<arr2[kk*2+1])maxpod=kk*2+1;
        if(kk==maxpod)break;
        var temp2=arr2[maxpod];
        arr2[maxpod]=arr2[kk];
        arr2[kk]=temp2;
        kk=maxpod;
    }
}


foreach(var item in arr2)
{
    Console.Write(item+" ");
}
Console.WriteLine();
Console.WriteLine("------------------");