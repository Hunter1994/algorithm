using System.Text;


Console.WriteLine(Encoding.ASCII.GetBytes("_")[0]);
Console.WriteLine(Encoding.ASCII.GetBytes("0")[0]);

Solution solution = new();
solution.AccountsMerge(new List<IList<string>>()
{
    // new List<string>(){ "John","johnsmith@mail.com","john_newyork@mail.com"},
    // new List<string>(){ "John","johnsmith@mail.com","john00@mail.com"},
    // new List<string>(){ "Mary","mary@mail.com"},
    // new List<string>(){ "John","johnnybravo@mail.com"}
new List<string>(){"David","David0@m.co","David1@m.co" },
new List<string>(){"David","David3@m.co","David4@m.co"},
new List<string>() { "David", "David4@m.co", "David5@m.co" },
new List<string>() { "David", "David2@m.co", "David3@m.co" },
new List<string>() { "David", "David1@m.co", "David2@m.co" }
});

public class Solution
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        Dictionary<string, List<int>> invertIndex = new Dictionary<string, List<int>>();

        for (int i = 0; i < accounts.Count; i++)
        {

            for (int j = 1; j < accounts[i].Count; j++)
            {
                if (!invertIndex.TryGetValue(accounts[i][j], out var mail))
                {
                    invertIndex.Add(accounts[i][j], new List<int>());
                }
                if (!invertIndex[accounts[i][j]].Contains(i))
                {
                    invertIndex[accounts[i][j]].Add(i);
                }

            }
        }
        invertIndex = invertIndex.OrderByDescending(r => r.Value.Count()).ToDictionary();

        // IList<IList<string>> res = new List<IList<string>>();
        bool[] ignoreIndex = new bool[accounts.Count];
        Queue<List<int>> quque = new Queue<List<int>>();
        // Dictionary<string, List<string>> res = new Dictionary<string, List<string>>();
        // Dictionary<int, int> nameIndex = new Dictionary<int, int>();
        // foreach (var item in invertIndex)
        // {

        // }


        foreach (var item in invertIndex.Values)
        {
            foreach (var i in item)
            {
                if (ignoreIndex[i]) continue;


                ignoreIndex[i] = true;
            }
        }

        Dictionary<List<string>, List<string>> res = new Dictionary<List<string>, List<string>>();
        foreach (var item in invertIndex)
        {


            var name = accounts[item.Value[0]][0];

            if (res.TryGetValue(name, out var m))
            {


            }
        }

        var map = accounts.Select(r => r.Distinct().ToDictionary(r => r, r => r)).ToList();

        var n = accounts.Count();
        IList<IList<string>> res = new List<IList<string>>();

        Queue<string> quque = new Queue<string>();
        for (int i = 0; i < n; i++)
        {
            if (ignoreIndex[i]) continue;

            var m = map[i];

            foreach (var item in m)
            {
                quque.Enqueue(item.Key);
            }

            while (quque.Count() > 0)
            {
                var str = quque.Dequeue();
                Find(ignoreIndex, map, n, m, quque, str, i + 1);
            }
            var data = m.Keys.ToList();
            var name = data[0];
            data.RemoveAt(0);
            data.Sort(new ASCIISort());
            data.Insert(0, name);
            res.Add(data);
        }
        return res;
    }

    private void Find(bool[] ignoreIndex, IList<Dictionary<string, string>> accounts, int n, Dictionary<string, string> data, Queue<string> quque, string str, int index)
    {
        if (index >= n) return;
        if (accounts[index].TryGetValue(str, out var s) && !ignoreIndex[index])
        {
            foreach (var item in accounts[index])
            {
                if (!data.TryGetValue(item.Key, out var ss))
                {
                    data.Add(item.Key, item.Key);
                    quque.Enqueue(item.Key);
                }
            }
            ignoreIndex[index] = true;
        }
        Find(ignoreIndex, accounts, n, data, quque, str, ++index);
    }

    public class ASCIISort : IComparer<String>
    {
        public int Compare(string? x, string? y)
        {
            var xs = Encoding.ASCII.GetBytes(x);
            var ys = Encoding.ASCII.GetBytes(y);
            for (int i = 0; i < Math.Min(xs.Length, ys.Length); i++)
            {
                if (xs[i] < ys[i]) return -1;
                if (xs[i] > ys[i]) return 1;
            }

            // 如果前面的字符都相同，比较长度
            if (xs.Length < ys.Length)
                return -1;
            else if (xs.Length > ys.Length)
                return 1;
            else
                return 0; // 相等

        }
    }
}