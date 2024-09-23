public class SubsetSumProblem
{
    public bool isSubsetSum(int N, int[] arr, int sum){
        // code here 
        bool [,] dp = new bool[N + 1, sum + 1];
        for (int i = 0; i <= N; i++)
        {
            dp[i, 0] = true; // A sum of 0 can always be achieved with an empty subset
        }
        for (int i = 1; i <= N; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                if(arr[i - 1] <= j)
                {
                    int rCap = j - arr[i - 1];
                    dp[i, j] = dp[i - 1, j] || dp[i - 1, rCap];
                }
                else{
                    // Exclude the item
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }
        return dp[N, sum];
    }
}