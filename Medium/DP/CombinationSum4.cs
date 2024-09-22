public class CombinationSum4
{
    public int CombinationSum(int[] nums, int target) {
        int[] dp = new int[target + 1];
        Array.Fill(dp, 0);
        dp[0] = 1;

        for (int i = 1; i <= target; i++)
        {
            foreach (int num in nums)
            {
                if (i - num >= 0)
                {
                    dp[i] += dp[i - num];
                }
            }
        }

        return dp[target];
    }
}