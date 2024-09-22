using Microsoft.VisualBasic;

public class MinOperationDivisible
{
    public int MinimumOperations(int[] nums) {
        if(nums == null || nums.Length == 0)
            return 0;

        int ops = 0;
        for (int I = 0; I < nums.Length; I++)
        {
            if(nums[I] < 3 || nums[I] % 3 != 0)
            {
                ops++;
            }
        }
        return ops;
    }

    public int MinOperations(int[] nums) {
        if(nums == null || nums.Length == 0)
            return 0;
        for (int I = 0; I < nums.Length - 2; I++)
        {
            if(nums[I] == 0){
                flipNums(nums, I);
            }
        }
        return 0;
    }

    private void flipNums(int[] nums, int ind)
    {
        if(nums[ind] - 0 == 1)
            nums[ind] = 0;
        else
            nums[ind] = 1;
        
        if(nums[ind + 1] - 0 == 1)
            nums[ind + 1] = 0;
        else
            nums[ind + 1] = 1;
        
        if(nums[ind + 2] - 0 == 1)
            nums[ind + 2] = 0;
        else
            nums[ind + 2] = 1;

        return;
    }

    public int MinOperations2(int[] nums) {
        if(nums == null || nums.Length == 0)
            return -1;
        int prev = 1, ops = 0;
        foreach (int item in nums)
        {
            if(item == 0)
            {
                if(prev == 1)
                {
                    ops++;
                }
                prev = 0;
            }
            else{
                if(prev == 0 && item == 1)
                {
                    ops++;
                }
                prev = 1;
            }
        }
        return ops;
    }
}