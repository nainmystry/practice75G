using System.Text;

public class SOlution405
{
    #region Q1
    /*
    100339. Find the Encrypted String
    You are given a string s and an integer k. Encrypt the string using the following algorithm:
    For each character c in s, replace c with the kth character after c in the string (in a cyclic manner).
    Return the encrypted string.
    */

    public string GetEncryptedString(string s, int k) {
        if(string.IsNullOrEmpty(s)) return string.Empty;
        if(k > s.Length)
        {
            while(k > s.Length)
            {
                k = k - s.Length;
            }
        }
        StringBuilder preSB = new StringBuilder();
        StringBuilder postSB = new StringBuilder();
        for (int I = 0; I < s.Length; I++)
        {
            if(I >= k)
            {
                postSB.Append(s[I]);
            }
            else{
                preSB.Append(s[I]);
            }
        }

        var res = postSB.ToString() + preSB.ToString();
        return res;

    }
    #endregion
    #region Q2
    /*
    100328. Generate Binary Strings Without Adjacent Zeros
    You are given a positive integer n.
    A binary string x is valid if all substrings of x of length 2 contain at least one "1".
    Return all valid strings with length n, in any order.
    */

    public IList<string> ValidStrings(int n) {
        var ans = new List<string>();
        ComputeString(n,string.Empty,ans);
        return ans;
    }

    private void ComputeString(int n, string prefix, List<string> ans)
    {
        if(n == 0)
        {
            ans.Add(prefix);
            return;
        }
        ComputeString(n - 1, prefix+"1", ans);
        if(prefix.Length == 0 || prefix[prefix.Length - 1] != '0')
        ComputeString(n-1, prefix+"0",ans);
    }

    #endregion
    #region Q3
    /*
    100359. Count Submatrices With Equal Frequency of X and Y
    Given a 2D character matrix grid, where grid[i][j] is either 'X', 'Y', or '.', 
    return the number of submatrices that contains:
        grid[0][0]
        an equal frequency of 'X' and 'Y'.
        at least one 'X'.
    */
 
    public int NumberOfSubmatrices(char[][] grid)
    {
        var total = 0;

        var gridX = new int[grid.Length, grid[0].Length];
        var gridY = new int[grid.Length, grid[0].Length];
        
        for (int row = 0; row < grid.Length; row++)
        {
            var colXCount = 0;
            var colYCount = 0;
            for (int col = 0; col < grid[0].Length; col++)
            {
                if (grid[row][col] == 'X')
                {
                    colXCount++;
                }else if (grid[row][col] == 'Y')
                {
                    colYCount++;
                }

                if (row - 1 >= 0)
                {
                    gridX[row, col] = gridX[row - 1, col] + colXCount;
                    gridY[row, col] = gridY[row - 1, col] + colYCount;
                }
                else
                {
                    gridX[row, col] = colXCount;
                    gridY[row, col] = colYCount;
                }

                if (gridX[row, col] == gridY[row, col] && gridX[row, col] != 0)
                {
                    total++;
                }
            }
        }

        return total;
    }

    #endregion
#region Q4
/*
3213. Construct String with Minimum Cost
You are given a string target, an array of strings words, and an integer array costs, 
both arrays of the same length.
Imagine an empty string s.
You can perform the following operation any number of times (including zero):
    Choose an index i in the range [0, words.length - 1].
    Append words[i] to s.
    The cost of operation is costs[i].
Return the minimum cost to make s equal to target. If it's not possible, return -1.
*/

//Approach 1 using DP -- Too much time
    public int MinimumCost(string target, string[] words, int[] costs) {
        int n = target.Length;
        int[] dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;
        StringBuilder sb = new StringBuilder(target);
        for (int I = 0; I < n; I++)
        {
            if(dp[I] == int.MaxValue) continue;

            for (int II = 0; II < words.Length; II++)
            {
                string word = words[II];
                int wordlength = word.Length;
                if(I + wordlength <= n && target.Substring(I, wordlength)==word)
                {
                    dp[I+wordlength] = Math.Min(dp[I+wordlength],dp[I] + costs[II]);
                }
            }
        }
        return dp[n] == int.MaxValue ? -1 : dp[n];
    }

//Approach 2 using DP + Trie


    public int MinCostToFormTarget(string target, string[] words, int[] costs)
    {
        // Step 1: Build the Trie
        TrieNode root = BuildTrie(words, costs);
        
        // Step 2: Initialize the DP array
        int n = target.Length;
        int[] dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        // Step 3: DP with Trie
        for (int i = 0; i < n; i++)
        {
            if (dp[i] == int.MaxValue) continue;
            TrieNode node = root;
            for (int j = i; j < n; j++)
            {
                char c = target[j];
                if (!node.Children.ContainsKey(c)) break;
                node = node.Children[c];
                if (node.IsWordEnd)
                {
                    dp[j + 1] = Math.Min(dp[j + 1], dp[i] + node.Cost);
                }
            }
        }

        // Step 4: Return result
        return dp[n] == int.MaxValue ? -1 : dp[n];
    }

    private TrieNode BuildTrie(string[] words, int[] costs)
    {
        TrieNode root = new TrieNode();
        for (int i = 0; i < words.Length; i++)
        {
            TrieNode node = root;
            foreach (char c in words[i])
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.IsWordEnd = true;
            node.Cost = Math.Min(node.Cost, costs[i]);
        }
        return root;
    }

    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
        public bool IsWordEnd { get; set; } = false;
        public int Cost { get; set; } = int.MaxValue;
    }


#endregion
}