public class DailyTemperature
{
    //TLE Error
    public int[] DailyTemperatures1(int[] temperatures) {
        if(temperatures.Length == 1) return new int[] {0};

        int left = 0, n = temperatures.Length;
        int[] ans = new int[temperatures.Length];
        while(left < n)
        {
            int i = left + 1;
            while (i < n && temperatures[i] <= temperatures[left]) {
                i++;
            }
            if (i < n) {
                ans[left] = i - left;
            }
            left++;
        }
        return ans;
    }

    //Using Stack 
    //keep on storing indices in stack until the higher temperature is found
    //once higher temp is found, start poping elems from stack
    public int[] DailyTemperatures(int[] temperatures)
    {
        int n = temperatures.Length;
        int[] answer = new int[n];
        Stack<int> stack = new Stack<int>(); // Store indices
        
        for (int i = 0; i < n; i++) {
            // Check if the current temperature is warmer than the temperature at indices in the stack
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()]) {
                int idx = stack.Pop();
                answer[idx] = i - idx; // Calculate days to wait
            }
            stack.Push(i); // Push current index onto the stack
        }
        
        return answer;
    }
}