public class MaxSubarray {
    //Kadane's Algo
    int currentTotal = 0;
    int maxTotal = int.MinValue;
    public int MaxSubArray(int[] nums) {
        try{
            if(nums.Length == 1){
                return nums[0];
            }
            else{
                return KadaneAlgo(nums);
            }
        }
        catch(Exception ex){
            throw;
        }
    }

/*
Brute Force Approach-
- First, we will run a loop(say i) that will select every possible starting index of the subarray. 
    The possible starting indices can vary from index 0 to index n-1(n = size of the array).
- Inside the loop, we will run another loop(say j) that will signify the ending index of the subarray. 
    For every subarray starting from the index i, the possible ending index can vary from index i to n-1(n = size of the array).
- After that for each subarray starting from index i and ending at index j (i.e. arr[i….j]), we will run another loop to calculate the sum of all the elements(of that particular subarray).
*/
    private int CalculateSum(int[] nums){
        try
        {
            int N = nums.Length;
            for (int I = 0; I < N; I++)
            {
                for (int II = I; II < N; II++)
                {
                    currentTotal = 0;

                    for (int III = I; III <= II; III++)
                    {
                        currentTotal += nums[III];
                    }

                    maxTotal = Math.Max(currentTotal, maxTotal);
                }
            }
            return maxTotal;
        }
        catch (System.Exception ex)
        {
            
            throw;
        }
    }

/*
Same as above instead of running third loop, we will do below step
- Inside loop j, we will add the current element to the sum of the previous subarray i.e. sum = sum + arr[j]. 
  Among all the sums the maximum one will be the answer.
*/
    private int CalculateSum2(int[] nums){
        try
        {
            int N = nums.Length;
            for (int I = 0; I < N; I++)
            {
                currentTotal = 0;
                for (int II = I; II < N; II++)
                {                                        
                    currentTotal += nums[II];                    
                    maxTotal = Math.Max(currentTotal, maxTotal);
                }
            }
            return maxTotal;
        }
        catch (System.Exception ex)
        {
            
            throw;
        }
    }

    private int KadaneAlgo(int[] nums){
        if (nums == null || nums.Length == 0)
        {
            throw new ArgumentException("Array cannot be null or empty.");
        }
        int maxCurrent = nums[0];
        int maxGlobal = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            maxCurrent = Math.Max(nums[i], maxCurrent + nums[i]); //Important line for Kadane's algo.
            if (maxCurrent > maxGlobal)
            {
                maxGlobal = maxCurrent;
            }
        }

        return maxGlobal;
    } 
}