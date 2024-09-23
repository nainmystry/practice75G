public class MaxCutSegments
{
    public int maximizeTheCuts(int n, int x, int y, int z)
    {
        //Your code here
        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            dp[i] = int.MinValue;
        }

        dp[0] = 0;

        for(int i = 1; i <= n; i++)
        {
            if(i >= x && dp[i - x] != int.MinValue)
                dp[i] = Math.Max(dp[i], dp[i - x] + 1);
            if(i >= y && dp[i - y] != int.MinValue)
                dp[i] = Math.Max(dp[i], dp[i - y] + 1);
            if(i >= z && dp[i - z] != int.MinValue)
                dp[i] = Math.Max(dp[i], dp[i - z] + 1);
        }

        return dp[n] < 0 ? 0 : dp[n];
    }
}