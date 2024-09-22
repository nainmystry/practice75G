using System.ComponentModel;

//toughest
public class FindClosestElement
{
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        List<int> ans = new List<int>();
        if(arr.Length == 0) return ans;
        int n = arr.Length;
        var closestIndex = BSClosestElement2(arr, x);
        
        int left = Math.Max(0, closestIndex - k);
        int right = Math.Min(arr.Length - 1, closestIndex + k);

        while (right - left < k) {
            if (left >= 0 && (right >= n || Math.Abs(arr[left] - x) <= Math.Abs(arr[right] - x))) {
                left--;
            } else {
                right++;
            }
        }
        var ak = arr[left..(right)];
        //ans.Add(arr[closestIndex]);
        // while(ans.Count < k)
        // {
        //     if(left >= 0 && right < arr.Length)
        //     {
        //         int leftdiff = Math.Abs(arr[left] - x);
        //         int rightDiff = Math.Abs(arr[right] - x);

        //         if(leftdiff <= rightDiff)
        //         {
        //             ans.Insert(0, arr[left]);
        //             left--;
        //         }
        //         else{
        //             ans.Add(arr[right]);
        //             right++;
        //         }
        //     }
        //     else if (left >= 0)
        //     {
        //         ans.Insert(0,arr[left]);
        //         left--;
        //     }
        //     else if (right < arr.Length)
        //     {
        //         ans.Add(arr[right]);
        //         right++;
        //     }

        // }
        
        return ans;
    }

    private int BSClosestElement(int[] arr, int x)
    {
        int low = 0, high = arr.Length - 1;

        while(low < high)
        {
            int mid = low + (high - low) / 2;

            if(arr[mid] == x)
            return mid;
            else if (arr[mid] < x)
            low = mid + 1;
            else 
            high = mid -1;
        }

        return low;
    }

    public int BSClosestElement2(int[] arr, int target)
        {
            int start = 0, end = arr.Length - 1, mid = 0;
            while (start <= end)
            {
                mid = start + (end - start) / 2;
                if (arr[mid] == target) { return mid; }
                if (arr[mid] > target) { end = mid - 1; }
                else { start = mid + 1; }
            }
            return mid;
    }
}