public class MinimumInRotatedSortedArray
{
    public int FindMin(int[] nums) {
        //int ans = int.MaxValue;
        int low = 0, high = nums.Length - 1;
        while(low < high)
        {
            var mid = low + (high - low) / 2;
            if(nums[mid] < nums[high])
            high = mid;
            else
            low = mid + 1;
        }
        return nums[low];    
    }
}