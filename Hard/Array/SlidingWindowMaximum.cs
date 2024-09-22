public class SlidingWindowMaximum
{
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int n = nums.Length; 
        if(k == 1) return nums;
        int[] res = new int[n - k + 1];
        int ri = 0;
        LinkedList<int> deque = new LinkedList<int>();
        for (int i = 0; i < n; i++)
        {
            // Remove indices of elements that are out of the current window from the front of the Deque
            while (deque.Count > 0 && deque.First.Value < i - k + 1) {
                deque.RemoveFirst();
            }
            
            // Remove indices of elements that are smaller than the current element from the back of the Deque
            while (deque.Count > 0 && nums[deque.Last.Value] < nums[i]) {
                deque.RemoveLast();
            }
            
            // Add the current index to the back of the Deque
            deque.AddLast(i);
            
            // If the window has moved to the point where it contains 'k' elements, start storing the maximum for each window
            if (i >= k - 1) {
                res[ri++] = nums[deque.First.Value];
            }

        }
        return res;
    }
}