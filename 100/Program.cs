

using System.Collections;
using System.Runtime.CompilerServices;

HashTable<int, int> h = new(0);
h.Insert(1, 10);
h.Insert(2, 20);
h.Insert(3, 30);
h.Insert(4, 40);
h.Insert(5, 50);
h.Insert(6, 60);
h.Insert(7, 70);

Console.WriteLine(h.Get(2));
Console.WriteLine(h.Get(5));
h.DeleteKey(40);



public class HashTable<K, V> where K : IComparable
{
    private Node[] _buckets;
    private ulong _fastModMultiplier;

    public HashTable(int min)
    {
        var size = HashHelpers.GetPrime(min);
        _buckets = new Node[size];
        _fastModMultiplier = HashHelpers.GetFastModMultiplier((uint)size);

    }
    public void Show(int s)
    {
        uint code = (uint)s.GetHashCode();
        var a = HashHelpers.FastMod(code, (uint)_buckets.Length, _fastModMultiplier);
        Console.WriteLine("{0}:{1};{2}", s, s.GetHashCode(), a);
    }

    private uint GetIndex(uint hashcode)
    {
        return HashHelpers.FastMod(hashcode, (uint)_buckets.Length, _fastModMultiplier);
    }

    public void DeleteKey(K k)
    {
        uint hashCode = (uint)k.GetHashCode();
        var index = GetIndex(hashCode);
        ref var buckt = ref _buckets[index];
        if (buckt == null) return;
        var p = buckt;
        Node pp = null;

        while (p != null)
        {
            if (p.Key.CompareTo(k) == 0)
            {
                break;
            }
            pp = p;
            p = p.Next;
        }

        if (p == null) throw new Exception("未找到" + k.ToString());
        if (pp == null)
            buckt = buckt.Next;
        else
            pp.Next = pp.Next.Next;
    }
    public void Insert(K t, V v)
    {
        Node node = new(t, v);
        uint hashCode = (uint)t.GetHashCode();
        var index = GetIndex(hashCode);
        ref var buckt = ref _buckets[index];
        if (buckt == null)
        {
            buckt = node;
        }
        else
        {
            var p = buckt;
            while (p != null)
            {
                if (p.Key.CompareTo(t) == 0)
                {
                    throw new Exception("key必须唯一");
                }
                if (p.Next == null) break;
                p = p.Next;
            }
            p.Next = node;
        }
    }

    public V Get(K k)
    {
        uint hashCode = (uint)k.GetHashCode();
        var index = GetIndex(hashCode);
        ref var buckt = ref _buckets[index];
        if (buckt == null) return default(V);

        var p = buckt;
        while (p != null)
        {
            if (p.Key.CompareTo(k) == 0)
            {
                return p.Value;
            }
            p = p.Next;
        }
        return default(V);
    }



    public class Node
    {
        public Node Next { get; set; }
        public K Key { get; set; }
        public V Value { get; set; }
        public Node(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}