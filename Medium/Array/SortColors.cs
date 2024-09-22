using System.Globalization;

public class SortColors
{
    
/*
Dutch National Flag Problem - three-way partitioning method
Algorithm Steps:
- Initialize Three Pointers:
    low: Tracks the boundary for red (0).
    mid: Current element under consideration.
    high: Tracks the boundary for blue (2).
- Iterate Through the Array:
    - If nums[mid] is 0 (red):
      Swap nums[low] and nums[mid].
      Increment low and mid.
    - If nums[mid] is 1 (white):
      Just increment mid.
    - If nums[mid] is 2 (blue):
      Swap nums[mid] and nums[high].
      Decrement high.
*/    
//Revise

public void SortCOlors(int[] nums)
{
    int low = 0, mid = 0, high = nums.Length - 1;
    while(mid <= high)
    {
        if(nums[mid] == 0)
        {
            Swap(nums, low, mid);
            low++;
            mid++;
        }
        else if(nums[mid] == 1)
        {
            mid++;
        }
        else{
            Swap(nums,mid,high);
            high--;
        }
    }

}

    private void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }


}