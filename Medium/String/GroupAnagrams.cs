public class GroupAnagram
{
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> ans = new Dictionary<string, List<string>>();
        foreach (string item in strs)
        {
            var charArray = item.ToCharArray();
            Array.Sort(charArray);
            var key = string.Join("",charArray);
            if(!ans.ContainsKey(key))
            {
                ans[key] = new List<string>();
            }
            ans[key].Add(item);
        }
        return new List<IList<string>>(ans.Values);        
    }
}