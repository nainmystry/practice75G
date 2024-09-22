public class LongestValidParenthesiss
{
    public int LongestValidParentheses1(string s) {
        if(string.IsNullOrEmpty(s))
        return 0;
        int res = 0, maxRes = 0;
        Stack<char> chars = new Stack<char>();
        foreach (char c in s)
        {
            if(c == '(')
            chars.Push('(');
            else
            {
                if(chars.Count > 0)
                {
                    chars.Pop();
                    res+=2;
                }
                else{
                    res = 0;
                }                
            }
            maxRes = Math.Max(res,maxRes);
        }
        return maxRes;

    }

    public int LongestValidParentheses(string s) 
    {
        if(string.IsNullOrEmpty(s))
        return 0;
        int res = 0, maxRes = 0;
        Stack<int> chars = new Stack<int>();
        foreach (char c in s)
        {
            if(c == '(')
            {
                chars.Push(res);
                res = 0;
            }
            else
            {
                if(chars.Count > 0)
                {
                    int prevCount = chars.Pop();
                    res = res + 2 + prevCount;
                    maxRes = Math.Max(maxRes, res);
                }
                else{
                    res = 0;
                }                
            }
        }
        return maxRes;
    }

    public int LongestValidParenthesesDP(string s) 
    {
        int n = s.Length;
        if (n == 0)
            return 0;
        
        int[] dp = new int[n];
        int maxLength = 0;

         // Start iterating from index 1 because a valid substring can't start at 0
        for (int i = 1; i < n; i++)
        {
            if (s[i] == ')')
            {
                // Case 1: Current character is ')', previous is '(' -> valid "()" pair
                if (s[i - 1] == '(')
                {
                    dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                }
                // Case 2: Current character is ')', and character before dp[i-1] is '('
                else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
                {
                    dp[i] = dp[i - 1] + ((i - dp[i - 1] >= 2) ? dp[i - dp[i - 1] - 2] : 0) + 2;
                }

                // Update maxLength
                maxLength = Math.Max(maxLength, dp[i]);
            }
        }

        return maxLength;
    }
}
