public class AccountsMerges
{

//Example: Disjoint Set
/*
A Disjoint Set (or Union-Find) is a data structure that keeps track of a collection of non-overlapping sets. 
It supports two primary operations:
Union: Merges two sets into a single set.
Find: Determines which set a particular element belongs to.
*/

//Revise
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        var ans = new List<IList<string>>();
        try
        {
            Dictionary<string, int> dict = new ();
            DisjointSet ds = new DisjointSet(accounts.Count);
            for(int i = 0; i < accounts.Count; i++)
            {
                for(int j = 1; j < accounts[i].Count; j++)
                {
                    if(dict.ContainsKey(accounts[i][j]))
                    {
                        ds.UnionBySize(dict[accounts[i][j]], i);
                    }
                    else
                    dict.Add(accounts[i][j], i);
                }
            }

            //Way 1
            List<string> [] mergedMail = new List<string>[accounts.Count];
            for(int i = 0; i < accounts.Count;i++)
            mergedMail[i] = new List<string>();
            foreach(var item in dict)
            {
                int ulp = ds.FindUltimateParent(item.Value);
                mergedMail[ulp].Add(item.Key);
            }
            
            for(int i = 0; i < accounts.Count; i++)
            {
                if(mergedMail[i].Count == 0)
                continue;
                mergedMail[i].Sort(StringComparer.Ordinal);
                var temp = new List<string>();
                temp.Add(accounts[i][0]);
                temp.AddRange(mergedMail[i]);
                ans.Add(temp);
            }
            

            //Way 2
            // var ans = new Dictionary<int,IList<string>>();
            // var mergedMails = dict.Keys.ToList();
            // mergedMails.Sort(StringComparer.Ordinal);
            // foreach(var item in mergedMails)
            // {
            //     int ulp = ds.FindUParent(dict[item]);
            //     if(ans.ContainsKey(ulp))
            //     ans[ulp].Add(item);
            //     else
            //     ans.Add(ulp, new List<string>{accounts[ulp][0], item});
            // }
            // return ans.Values.ToList();

        }
        catch (System.Exception)
        {
            
            throw;
        } 
        return ans;       
    }

    class DisjointSet
    {
        public List<int> parent = new ();
        List<int> size = new ();
        public DisjointSet(int V)
        {
            for(int i = 0; i < V; i++)
            {
                parent.Add(i);
                size.Add(1);
            }
        }

        public int FindUltimateParent(int node)
        {
            if(node != parent[node])
            {
                var parentNode = parent[node];
                return parent[node] = FindUltimateParent(parentNode);
            }
            return node;
        }

//ulpu - ultimate parent for U
//uplv - ultimate parent for V
//compare the roots, root with lower rank will be merged under the larger rank.
        public void UnionBySize(int u, int v)
        {
            int ulpu = FindUltimateParent(u);
            int ulpv = FindUltimateParent(v);
            if(ulpu == ulpv)
            return;

            if(size[ulpu] < size[ulpv])
            {
                parent[ulpu] = ulpv;
                size[ulpv] = size[ulpv] + size[ulpu];
            }
            else
            {
                parent[ulpv] = ulpu;
                size[ulpu] = size[ulpu] + size[ulpv];
            }
        }
    }
}


public class AccountsMerge2
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        
        var dic = new Dictionary<string, string>();
        for (var i = 0; i < accounts.Count; i++)
        {
            for (var j = 1; j < accounts[i].Count; j++)
            {
                if (!dic.ContainsKey(accounts[i][j]))
                {
                    dic[accounts[i][j]] = accounts[i][0];
                }
            } 
        }

        var set = new DSet(dic.Keys.ToArray());

        for (var i = 0; i < accounts.Count; i++)
        {
            for (var j = 2; j < accounts[i].Count; j++)
            {
                set.Union(accounts[i][1], accounts[i][j]);
            } 
        }           

        var groupedEmails = set.GetGroupedEmails();

        foreach (var emailGroup in groupedEmails)
        {
            var name = dic[emailGroup[0]];
            emailGroup.Insert(0, name);
        }

        return groupedEmails.Select(x => x.ToArray()).ToArray();
    }

    public class DSet {
        private readonly int[] _parents;
        private readonly int[] _ranks;
        private readonly Dictionary<string, int> _emails;
        private readonly string[] _indexToEmail;
        public int Size { get; }

        public DSet(string[] emails)
        {
            Size = emails.Length;
            _emails = new Dictionary<string, int>();
            _parents = new int[Size];
            _ranks = new int[Size];
            _indexToEmail = (string[]) emails.Clone();
            for (var i = 0; i < Size; i++)
            {
                _parents[i] = i;
                _ranks[i] = 1;
                _emails.Add(emails[i], i);
            }
        }

        private int GetParent(int v){
            if (_parents[v] != v)
            {
                return _parents[v] = GetParent(_parents[v]);
            }

            return _parents[v];
        }

        public void Union(string firstEmail, string secondEmail) {
            var x = _emails[firstEmail];
            var y = _emails[secondEmail];


            x = GetParent(x);
            y = GetParent(y);
            
            if (x == y)
            {
                return;
            }

            if (_ranks[x] > _ranks[y]) {
                (x,y) = (y,x);
            }

            if (_ranks[x] == _ranks[y])
            {
                _ranks[x]++;
                _parents[y] = _parents[x];
            } else {
                _parents[y] = _parents[x];
            }   
        }

        public List<List<string>> GetGroupedEmails() {
            var emailWithParent = new List<(string, int)>();
            for (var i = 0; i < Size; i++)
            {
                _parents[i] = GetParent(i);
                emailWithParent.Add((_indexToEmail[i], _parents[i]));
            }

            var groups = emailWithParent.GroupBy(x => x.Item2);

            var result = new List<List<string>>();
            foreach (var group in groups)
            {
                result.Add(
                    group
                    .Select(x => x.Item1)
                    .OrderBy(x => x, StringComparer.Ordinal)
                    .ToList());
            }

            return result;
        }
    }

}