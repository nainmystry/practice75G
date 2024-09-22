public class FindAllAnagramsInString
{
    //sort the substring and check if it is equal to p string
    //TLE Error
    public IList<int> FindAnagrams1(string s, string p) {

        if(s.Equals(p))
        return new List<int>(0);

        List<int> ans = new List<int>();
        int n = s.Length, m = p.Length;

        char[] sortedP = p.ToCharArray();
        Array.Sort(sortedP);
        p = new string(sortedP);
        string temp = string.Empty;
        for (int I = 0; I <= (n - m); I++)
        {
            temp = "";
            for (int II = I; II < m + I; II++)
            {
                temp+=s[II];
            }
            char[] sortedTemp = temp.ToCharArray();
            Array.Sort(sortedTemp);
            temp = new string(sortedTemp);
            if(p.Equals(temp))
            ans.Add(I);
        } 

        return ans;
    }

    //Sliding Window Approach
    public IList<int> FindAnagrams(string s, string p) {
        List<int> ans = new List<int>();
               
        int[] arr1=new int[26];
        int[] arr2=new int[26];
        int n = s.Length, m = p.Length;

        if(m > n)
        return ans;

        for (int I = 0; I < m; I++)
        {
            arr1[p[I] - 'a']++;
            arr2[s[I] - 'a']++;
        }
        if(arr1.SequenceEqual(arr2))
        {
            ans.Add(0);
        }

        //sliding window logic. Remove leftmost char & append next chars.
        for (int II = m; II < n; II++)
        {
            //slide window to the right
            arr2[s[II] - 'a']++;
            //remove leftmost character
            arr2[s[II - m] - 'a']--;
            if(Array.Equals(arr1,arr2))
            ans.Add(II - m + 1);
        }
        return ans;
    }
}