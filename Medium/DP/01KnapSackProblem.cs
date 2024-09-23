public class KnapSackProblem
{
    //GFG

    public int knapSack(int W, int[] wt, int[] val) {
        int ans = 0;
        int n = wt.Length;
        int[,] dp = new int[n + 1, W + 1];
        // for (int i = 0; i < dp.Length; i++)
        // {
        //     dp[i] = new int[W];
        // }
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= W; j++)
            {
                if (wt[i - 1] > j)
                {
                    // If the weight of the item is more than current capacity, skip it
                    dp[i, j] = dp[i - 1, j];
                }
                else
                {
                    int remainingWeightage = j - wt[i - 1];
                    // Choose the maximum of including or excluding the item
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, remainingWeightage] + val[i - 1]);
                }                
            }
        }

        return dp[n,W];

    }
}