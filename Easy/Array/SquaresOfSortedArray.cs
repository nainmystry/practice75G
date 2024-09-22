public class SquaresOfSortedArray
{
    public int[] SortedSquares(int[] nums) {
        for(int I = 0; I < nums.Length; I++)
        {
           nums[I] = (int)Math.Pow(nums[I], 2);
        }
        Array.Sort(nums);
        return nums;   
    }
}