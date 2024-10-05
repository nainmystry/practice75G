public class NextPermutations
{
    //Revise In-Place Algo
    public void NextPermutation(int[] nums) {
        int n = nums.Length;
        int I = n - 2;
        // Find the first decreasing element
        //from the end of the array
        while (I >= 0 && nums[I] >= nums[I + 1]) {
            I--;
        }

        // Find the next bigger element than nums[I] from the end, then swap it 
        if (I >= 0) {
            int j = n - 1;
            while (j >= 0 && nums[j] <= nums[I]) {
                j--;
            }
            Swap(nums, I, j);
        }

        //Reverse the suffix to get the lexicographically larger element 
        //if all the elements in array are in descending order, then just reverse the array 
        Reverse(nums, I + 1, n - 1);
        var res = "";
    }

    private void Swap(int[] nums, int i, int j)
    {
        var temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    private void Reverse(int[] nums, int start, int end)
    {
        while(start < end)
        {
            Swap(nums, start, end);
            start++;
            end--;
        }
    }
}