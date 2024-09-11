using System.Text;

Solution solution = new();
solution.AccountsMerge(new List<IList<string>>()
{
    // new List<string>(){ "John","johnsmith@mail.com","john_newyork@mail.com"},
    // new List<string>(){ "John","johnsmith@mail.com","john00@mail.com"},
    // new List<string>(){ "Mary","mary@mail.com"},
    // new List<string>(){ "John","johnnybravo@mail.com"}


    // new List<string>(){"David","David0@m.co","David1@m.co" },
    // new List<string>(){"David","David3@m.co","David4@m.co"},
    // new List<string>() { "David", "David4@m.co", "David5@m.co" },
    // new List<string>() { "David", "David2@m.co", "David3@m.co" },
    // new List<string>() { "David", "David1@m.co", "David2@m.co" }

// new List<string>(){"Ethan", "Ethan1@m.co", "Ethan2@m.co", "Ethan0@m.co" },
// new List<string>(){"David", "David1@m.co", "David2@m.co", "David0@m.co" },
// new List<string>(){ "Lily", "Lily0@m.co", "Lily0@m.co", "Lily4@m.co"},
// new List<string>(){ "Gabe", "Gabe1@m.co", "Gabe4@m.co", "Gabe0@m.co" },
// new List<string>(){ "Ethan", "Ethan2@m.co", "Ethan1@m.co", "Ethan0@m.co" }


new List<string>(){ "David","David0@m.co","David4@m.co","David3@m.co" },
new List<string>(){  "David","David5@m.co","David5@m.co","David0@m.co"},
new List<string>(){  "David","David1@m.co","David4@m.co","David0@m.co"},
new List<string>(){  "David","David0@m.co","David1@m.co","David3@m.co"},
new List<string>(){  "David","David4@m.co","David1@m.co","David3@m.co"}


});

public class Solution
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        Dictionary<string, int> emailToIndex = new Dictionary<string, int>();
        Dictionary<string, string> emailToName = new Dictionary<string, string>();

        int emailCount = 0;
        for (int i = 0; i < accounts.Count(); i++)
        {
            for (int j = 1; j < accounts[i].Count(); j++)
            {
                if (!emailToIndex.TryGetValue(accounts[i][j], out var e))
                {
                    emailToIndex.Add(accounts[i][j], emailCount++);
                    emailToName.Add(accounts[i][j], accounts[i][0]);
                }
            }
        }

        UnionFind u = new UnionFind(emailCount);
        for (int i = 0; i < accounts.Count; i++)
        {
            var firstIndex = emailToIndex[accounts[i][1]];
            for (int j = 2; j < accounts[i].Count(); j++)
            {
                var nextIndex = emailToIndex[accounts[i][j]];
                u.Union(firstIndex, nextIndex);
            }
        }

        Dictionary<int, List<string>> nameToEmail = new Dictionary<int, List<string>>();

        foreach (var item in emailToIndex)
        {
            var i = u.Find(item.Value);
            if (!nameToEmail.TryGetValue(i, out var e))
            {
                nameToEmail.Add(i, new List<string>());
            }
            nameToEmail[i].Add(item.Key);
        }

        List<IList<string>> res = new List<IList<string>>();
        foreach (var item in nameToEmail)
        {
            List<string> data = new List<string>();
            if (emailToName.TryGetValue(item.Value.FirstOrDefault(), out var name))
            {
                data.Add(name);
            }
            data.AddRange(item.Value.OrderBy(r => r, new ASCIICompara()).ToList());
            res.Add(data);
        }

        return res;
    }

}
public class UnionFind
{
    public int[] parent;
    public UnionFind(int n)
    {
        parent = new int[n];
        for (int i = 0; i < parent.Length; i++)
        {
            parent[i] = i;
        }
    }
    public void Union(int firstIndex, int nextIndex)
    {
        parent[Find(nextIndex)] = Find(firstIndex);
    }
    public int Find(int i)
    {
        if (parent[i] != i)
        {
            parent[i] = Find(parent[i]);
        }
        return parent[i];
    }

}

public class ASCIICompara : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        var xb = Encoding.ASCII.GetBytes(x);
        var yb = Encoding.ASCII.GetBytes(y);
        for (int i = 0; i < Math.Min(xb.Length, yb.Length); i++)
        {
            if (xb[i] < yb[i]) return -1;
            else if (xb[i] > yb[i]) return 1;
        }

        if (xb.Length > yb.Length) return -1;
        else if (xb.Length < yb.Length) return 1;
        else return 0;

    }
}