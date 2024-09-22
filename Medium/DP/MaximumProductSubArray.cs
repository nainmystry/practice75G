public class MaximumProductSubArray
{
    public int MaxProduct(int[] nums) {
        double max_product = nums[0], min_product = nums[0], max = nums[0];

        for (int I = 1; I < nums.Length; I++)
        {
            var temp = Math.Max(nums[I], Math.Max(max_product * nums[I], min_product * nums[I]));
            min_product = Math.Min(nums[I], Math.Min(max_product * nums[I], min_product * nums[I]));
            max_product = temp;
            max = Math.Max(max, max_product);
        }
        return (int) max;
    }
}