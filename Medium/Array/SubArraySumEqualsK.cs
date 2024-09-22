public class SubArraySumEqualsK
{
    public int SubarraySum(int[] nums, int k) {
        var prefixSumCount  = new Dictionary<int,int>();
        prefixSumCount[0] = 1;
        int currSum = 0;
        int count = 0;

        for (int I = 0; I < nums.Length; I++)
        {
            currSum += nums[I];
            if(prefixSumCount.TryGetValue(currSum - k,out int   freq))
            {
                count += freq;
            }

            if (prefixSumCount.ContainsKey(currSum))
            {
                prefixSumCount[currSum]++;
            }
            else
            {
                prefixSumCount[currSum] = 1;
            }
        }
        return count;
    }
}