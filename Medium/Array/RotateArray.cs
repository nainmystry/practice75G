using System.Globalization;

public class RotateArray
{

    //Failed Approach
    public void RotateFailed(int[] nums, int k) {
        if(nums.Length == 0) return;
        int n = nums.Length;
        int[] newnum = new int[n];
        Array.Copy(nums, newnum, n);        
        for (int I = k, II = 0; I < n; I++, II++)
        {
            nums[I] = newnum[II];
        }
        for(int I = 0; I < k; I++)
        {
            nums[I] = newnum[n - k + I];
        }        
    }

    public void Rotate(int[] nums, int k) {
        int n = nums.Length;

        k = k % n; //If K is greater than n;

        Reverse(nums, 0, n - 1);

        Reverse(nums,0,k-1);

        Reverse(nums,k,n-1);
    }

    private void Reverse(int[] nums, int start, int end)
    {
        while(start < end)
        {
            int temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;
            start++;
            end--;
        }
    }
}