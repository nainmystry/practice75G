public class DecodeWays
{
    public int NumDecodings(string s) {
        if(string.IsNullOrEmpty(s) || s.StartsWith('0')) return 0;
        int n = s.Length;
        int[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;
        for (int i = 2; i < n + 1; i++)
        {
            int oneDigit = s[i - 1] - '0';
            int twoDigit = int.Parse(s.Substring(i - 2, 2));

            if(oneDigit != 0)
            {
                dp[i] = dp[i-1];
            }

            if(10 <= twoDigit && twoDigit <= 26)
            {
                dp[i] += dp[i-2];
            }
        }
        return dp[n];
    }
}