public class PartitionEqualSubsetSum
{

//Failed
     public bool CanPartitionF(int[] nums) {
        Array.Sort(nums);

        int l = 0, r = nums.Length - 1, lSum = nums[0], rSum = nums[nums.Length - 1];
        bool partioned =false;
        List<int> lArr = new List<int>() ;
        List<int> rArr = new List<int>() ;
        while(l < r)
        {
            if(lSum < rSum)
            {
                lArr.Add(nums[l]);                
                if(l != 0)
                {
                    lSum += nums[l];
                }
                l++;
            }
            else if (lSum > rSum){
                rArr.Add(nums[r]);
                if(r != nums.Length - 1)
                {
                    rSum += nums[r];
                }
                r--;
            }
            else
            {
                l++;
                r++;
            }
        }
        return lSum == rSum;
    }

    public bool CanPartition(int[] nums) 
    {
       var sum = nums.Sum();  
       if(sum % 2 != 0)
       {
           return false;
       }
    
       int subArraySum = sum / 2;
    
       bool[] dp = new bool[subArraySum + 1];
       dp[0] = true;
    
       foreach (int num in nums)
       {
           for (int I = subArraySum; I >= num; I--)
           {
               dp[I] = dp[I] || dp[I - num];
           }
       }
       return dp[subArraySum];
    }

    public bool CanPartition2(int[] nums)
    {
        var sum = nums.Sum();

        if(sum % 2 != 0)
        {
            return false;
        }

        var targetSum = sum / 2;
        int n = nums.Length;

        bool[,] dp = new bool[n + 1, targetSum + 1];
        for (int i = 0; i <= n; i++)
        {
            dp[i,0] = true;
        }
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= targetSum; j++)
            {
                if(nums[i - 1] <= j)
                {
                    var rCap = j - nums[i - 1];
                    dp[i,j] = dp[i - 1,j] || dp[i - 1, rCap];
                }
                else{
                    dp[i,j] = dp[i - 1,j];
                }
            }
        }
        return dp[n, targetSum];        
    }
}