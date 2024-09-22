public class SearchinRotatedSortedArray
{
    /*
    Even if the array is rotated, one of the 2 halves will always be sorted. 
    To efficiently search for a target value using this observation, we will follow a simple two-step process. 
        First, we identify the sorted half of the array. 
        Once found, we determine if the target is located within this sorted half. 
        If not, we eliminate that half from further consideration. 
        Conversely, if the target does exist in the sorted half, we eliminate the other half.
    */
    public int Search(int[] nums, int target) {
        int low = 0, high = nums.Length;

        while(low <= high){
            int mid = (low + high) / 2; //not safe form, should use mid = low + (high - low) / 2;

            if(nums[mid] == target)
                return mid;
            
            if(nums[low] <= nums[mid])
            {
                if (nums[low] <= target && target <= nums[mid])
                {
                    high = mid - 1;
                }
                else{
                    low = mid + 1;
                }
            }
            else{
                if(nums[mid] <= target && target <= nums[high]){
                    low = mid + 1;
                }
                else{
                    high = mid-1;
                }
            }
        }

        return -1;
    }
}