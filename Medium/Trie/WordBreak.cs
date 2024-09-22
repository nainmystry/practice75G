public class Wordbreak
{
    //Approach failed
    //Test Case: WordDict = ["car","ca", "rs"]
    public bool WordBreak1(string s, IList<string> wordDict) {
        if(wordDict == null)
        return false;

        foreach (string item in wordDict)
        {
            if(s.Contains(item))
            {
                s = s.Replace(item,"");
            }
        }

        return !string.IsNullOrEmpty(s);
    }
/*
Role of Each Loop:
- Outer Loop (I): Marks the end of the current substring being considered.
- Inner Loop (II): Finds the start of the current word being checked in the substring ending at I.
*/
//DP Approach
    public bool WordBreakDP(string s, List<string> wordDict)
    {
        int n = s.Length;
        bool[] dp = new bool[n + 1];
        dp[0] = true; // base case: an empty string can be segmented
        HashSet<string> wordSet = new HashSet<string>(wordDict);
        for (int I = 1; I <= n; I++)
        {
            for (int II = 0; II < I; II++)
            {
                string word = s.Substring(II, I - II);
                if (dp[II] && wordSet.Contains(word))
                {
                    dp[I] = true;
                    break; // Found a segmentation, move to next I
                }
            }
        }
        return dp[n];
    }

//Trie Approach
    public bool WordBreak(string s, List<string> wordDict)
    {
        Trie trie = new Trie();
        foreach (string word in wordDict)
        {
            trie.Insert(word);
        }

        int n = s.Length;
        bool[] dp = new bool[n + 1];
        dp[0] = true; // Base case: an empty string can always be segmented

        for (int I = 1; I <= n; I++)
        {
            for (int II = 0; II < I; II++)
            {
                if (dp[II] && trie.Search(s.Substring(II, I - II)))
                {
                    dp[I] = true;
                    break; // Found a valid segmentation, move to the next I
                }
            }
        }

        return dp[n];
    }

}