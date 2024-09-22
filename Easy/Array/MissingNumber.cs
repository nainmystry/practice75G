public class MissingNumbers
{
    public int MissingNumber1(int[] nums) {
        int n = nums.Length;
        int sum = n * (n + 1) / 2;

        foreach (int val in nums) {
            sum -= val;
        }
        return sum;
    }

    public int MissingNumber(int[] nums)
    {
	    int x = nums.Length;
    
	    for (int i = 0; i < nums.Length; i++)
	    {
	    	x ^= i ^ nums[i];
	    }
    
	    return x;
    }
}