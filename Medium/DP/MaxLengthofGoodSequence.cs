public class MaxLengthofGoodSequence
{
    public int MaximumLength(int[] nums, int k) {
        int n = nums.Length;
        if (n == 0) return 0;

        int[][] dp = new int[n][];
        for (int i = 0; i < n; ++i) {
            dp[i] = new int[k + 1];
        }
        for (int i = 0; i < n; ++i) dp[i][0] = 1;

        int res = 1;
        for (int j = 0; j <= k; ++j) {
            int max1 = 1;
            Dictionary<int, int> numMap = new Dictionary<int, int>();
            numMap[nums[0]] = 0;

            for (int i = 1; i < n; ++i) {
                dp[i][j] = 1;
                if (i > 0 && j > 0) max1 = Math.Max(max1, dp[i - 1][j - 1] + 1);
                dp[i][j] = Math.Max(dp[i][j], max1);

                if (numMap.ContainsKey(nums[i])) {
                    dp[i][j] = Math.Max(dp[i][j], dp[numMap[nums[i]]][j] + 1);
                }

                numMap[nums[i]] = i;
                res = Math.Max(res, dp[i][j]);
            }
        }

        return res;
    }
}