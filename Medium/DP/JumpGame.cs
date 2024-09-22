public class JumpGame
{
    //TLE
    public bool CanJump(int[] nums) {
        if(nums.Length == 0) return false;

        int step = 0, jumps = 0;        
        int n = nums.Length - 1;
        for (int I = 0; I < n; I++)
        {
            if(step > jumps)
            return false;

            jumps = Math.Max(jumps, step + nums[step]);   
        }
        return true;
    }

    public bool CanJump2(int[] nums) 
    {
        int finishIndex = nums.Length - 1;
        int n = nums.Length - 1;
        for (int I = n; I >= 0; I--)
        {
            if(I + nums[I] >= finishIndex)
            {
                if(I == 0) return true;
                finishIndex = I;
            }
        }
        return false;
    }

    public bool CanJump1(int[] nums) {
        int n = nums.Length;
        int maxReach = 0; // Initialize the furthest position you can reach
        
        for (int i = 0; i < n; i++) {
            if (i > maxReach) {
                // If the current position is beyond the furthest reach, return false
                return false;
            }
            // Update the furthest position you can reach
            maxReach = Math.Max(maxReach, i + nums[i]);
        }
        
        // If you completed the loop, it means you can reach the end
        return true;
    }
}