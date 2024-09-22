public class BiContest137
{

    //sliding window approach
    public int[] ResultsArray(int[] nums, int k) {
        int n = nums.Length;
        int[] results = new int[n - k + 1];

        for (int I = 0; I <= n - k; I++)
        {
            bool consecutive = true;
            int maxelem = nums[I];
            
            for (int II = I + 1; II < I + k; II++)
            {
                if(nums[II] != nums[II - 1] + 1) //consecutive & sorted validation
                {
                    consecutive = false;
                    break;
                }
                maxelem = Math.Max(maxelem, nums[II]);
            }

            if (consecutive)
                results[I] = maxelem;
            else
                results[I] = -1;
        }        
        return results;
    }

    //using double queue
    public int[] FindSubarrayPowers1(int[] nums, int k)
    {
        int n = nums.Length;
        int[] results = new int[n - k + 1];
        LinkedList<int> deque = new LinkedList<int>();

        for (int i = 0; i < n; i++)
        {
            if (deque.Count > 0 && deque.First.Value < i - k + 1)
            {
                deque.RemoveFirst();
            }

            while (deque.Count > 0 && nums[deque.Last.Value] <= nums[i])
            {
                deque.RemoveLast();
            }

            deque.AddLast(i);

            if (i >= k - 1)
            {
                int start = i - k + 1;
                int maxElement = nums[deque.First.Value];
                bool consecutive = true;
                for (int j = start + 1; j <= i; j++)
                {
                    if (nums[j] != nums[j - 1] + 1)
                    {
                        consecutive = false;
                        break;
                    }
                }
                if(consecutive)
                results[start] = maxElement;
                else
                results[start] = -1;
            }
        }

        return results;
    }

    public int[] FindSubarrayPowers(int[] nums, int k)
    {
        int n = nums.Length;
        int[] ans = new int[n - k + 1];

        for (int I = 0; I <= n - k; I++)
        {
            // Use HashSet to track the elements in the subarray
            HashSet<int> set = new HashSet<int>();
            int minElem = nums[I];
            int maxElem = nums[I];

            // Traverse the window and update min/max and HashSet
            for (int II = I; II < I + k; II++)
            {
                set.Add(nums[II]);
                minElem = Math.Min(minElem, nums[II]);
                maxElem = Math.Max(maxElem, nums[II]);
            }

            // Check if the subarray is consecutive
            if (maxElem - minElem == k - 1 && set.Count == k && set.First() == minElem && set.Last() == maxElem)
            {
                ans[I] = maxElem; // Subarray is consecutive, store the max element
            }
            else
            {
                ans[I] = -1; // Subarray is not consecutive
            }
        }

        return ans;
    }

    public int[] ResultsArray1(int[] nums, int k) {
        int n = nums.Length;
        int[] results = new int[n - k + 1];

        for (int I = 0; I <= n - k; I++)
        {
            bool consecutive = true;
            //int maxelem = nums[I];
            
            int left = I;
            int right = I + k - 1;
            int length = right - left + 1;
            int[] subarray = new int[length];
            int maxelem = nums[right];
            Array.Copy(nums, left, subarray, 0, length);
            if(subarray.Distinct().Count() != subarray.Length)
            consecutive = false;
            while (left < right && consecutive)
            {
                if (nums[left] >= nums[left + 1] || nums[right] <= nums[right - 1])
                {
                    consecutive = false;
                    break;
                } 

                if (nums[left + 1] != nums[left] + 1 || nums[right - 1] != nums[right] - 1)
                {
                    consecutive = false;
                    break;
                }

                left++;
                right--;
            }

            if (consecutive)
                results[I] = maxelem;
            else
                results[I] = -1;
        }        
        return results;
    }
}