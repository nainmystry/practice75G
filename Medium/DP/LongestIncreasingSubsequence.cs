public class LongestIncreasingSubsequence
{
    //DP Approach
    public int LengthOfLIS(int[] nums) 
    {
        int n = nums.Length;
        if (n == 0) return 0;
        
        int[] dp = new int[n]; 
        Array.Fill(dp,1); //Initial Value of Sub Array will be 1 since min length can be one.

        for (int I = 1; I < n; I++)
        {
            for (int II = 0; II < I; II++)
            {
                if(nums[II] < nums[I])
                {
                    dp[I] = Math.Max(dp[I], dp[II]+1); 
                    //everytime a number smaller than I is found, it increments the value of  
                    //dp index of lower value by 1.
                    //since it iterates over values of all the indexes, it uses a math.max function
                }
            }            
        }

        int longest = 0;
        for (int I = 0; I < n; I++)
        {
         longest = Math.Max(longest,dp[I]);   
        }
        return longest;
    }

    //Binary Search - Patience Sorting Algorithm
    public int LengthOfLISBS(int[] nums)    
    {
        int[] tails = new int[nums.Length];
        int size = 0;

        foreach (int x in nums)
        {
            int left = 0, right = size;
            while (left != right)
            {
                int mid = (left + right) / 2;
                if (tails[mid] < x)
                    left = mid + 1;
                else
                    right = mid;
            }
            tails[left] = x;
            if (left == size)
                size++;
        }

        return size;
    }
}