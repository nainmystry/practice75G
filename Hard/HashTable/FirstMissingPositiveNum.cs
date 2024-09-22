public class FirstMissingPositiveNum
{
    public int FirstMissingPositive(int[] nums)
    {
        int N = nums.Length;
        for (int i = 0; i < N; i++)
        {
            if(nums[i] < 0)
            nums[i] = 0;
        }

        for (int i = 0; i < N; i++)
        {
            var val = Math.Abs(nums[i]);
            if(1 <= val && val <= N)
            {
                if(nums[val - 1] > 0)
                nums[val - 1] *= -1;
                else if(nums[val - 1] == 0)
                nums[val - 1] = -1 * N + 1; 
            }
        }


        for (int i = 1; i < N + 1; i++)
        {
            if(nums[i - 1]>= 0)
            return i;
        }

        return N + 1;
    }

    //Correct ans but takes Space O(n)
    public int FirstMissingPositive1(int[] nums) {
        HashSet<int> hashs = new HashSet<int>(nums.ToHashSet());
        int max = nums.Length;
        for (int I = 1; I <= nums.Length + 1; I++)
        {
            if(!hashs.Contains(I))
            return I;
        }
        return 0;
    }

    //Wrong Approach
    public int FirstMissingPositive2(int[] nums) {
        List<int> ints = new List<int>();
        int max = 0, min = 1; 
        foreach (int num in nums)
        {
            if(num <= 0) continue;

            if(num == min)
            {
                min++;
            }
            else{
                return min;
            }
        }
        
        return min;
    }

    //TLE
    public int FirstMissingPositive3(int[] nums) {
        List<int> ints = new List<int>();
        var max = nums.Max();
        if(max <= 0) return 1;
        for (int I = 1; I <= max; I++)
        {
            if(!nums.Any(x => x == I))
            {
                return I;
            }
        }
        return max + 1;
    }
}