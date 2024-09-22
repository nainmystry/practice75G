public class HouseRobber
{
    public int Rob(int[] nums) {
        int n = nums.Length;
        int[] dp = new int[n];
        
        dp[0] = nums[0]; // Maximum money that can be robbed up to house 0
        dp[1] = Math.Max(nums[0], nums[1]); // Maximum money that can be robbed up to house 1
        
        for (int i = 2; i < n; i++) {
            // Two choices: rob current house i and add money robbed from i-2,
            // or skip current house i and take money robbed upto i-1 houses
            dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
        }
        
        return dp[n - 1]; // Maximum money that can be robbed up to the last house
        
    }

//Approach 2
    public int Rob2(int[] nums) {
        if(nums.Length == 1) 
            return nums[0];

        var prev = nums[0];
        var max = Math.Max(nums[1], prev);

        for(var i = 2; i < nums.Length; i++) {
            var temp = max;
            var curr = prev + nums[i];
            max = Math.Max(max, curr);
            prev = temp;
        }

        return max;
    }

}