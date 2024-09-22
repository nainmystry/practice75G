using System.Text;

public class LongestCommonPrefixs
{
    public string LongestCommonPrefix(string[] strs) {
        int i = 0;
        StringBuilder sb = new();
        string shortest = strs.OrderBy(s => s.Length).First();

        foreach (char c in shortest)
        {
            if (strs.Any(s => s[i] != c)) break;
            sb.Append(c);
            i++;
        }

        return sb.ToString();

    }
}