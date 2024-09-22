public class ThreeSumClosests
{
    public int ThreeSumClosestF(int[] nums, int target) {
        if(nums.Length < 3) return 0;

        int left = 0, right = 0, start = 0, N = nums.Length;
        Array.Sort(nums);
        HashSet<int> closestNum = new HashSet<int>();
        //if(target < 0) target = target*-1;
        while(start < N - 2)
        {
            left = start + 1;
            right = N - 1;
            while(left < right)
            {
                //if total is greater than sum, decrement right <- shift
                var sum = nums[left] + nums[right] + nums[start];
                if(sum == target) return target;
                closestNum.Add(sum);
                
                var prevLeft = nums[left];
                var prevRight = nums[right]; 
                //check the next left index, if it is same as current left, increment
                while (left < right && nums[left] == prevLeft)
                    ++left;
                //check the next right index, if it same as current right, decrement
                while (left < right && nums[right] == prevRight)
                    --right;
            }
            int currentStartNumber = nums[start];
            
            //Increment the start counter,  if the start number is same as current start, keep incrementing
            while (start < nums.Length - 2 && nums[start] == currentStartNumber) 
                ++start;
        }
        if(closestNum.Contains(target))
        return target;
        int nTarget = target - 1, pTarget = target + 1;
        while(!closestNum.Contains(nTarget) && !closestNum.Contains(pTarget))
        {
            nTarget--;
            pTarget++;
        }
        if(closestNum.Contains(nTarget))
        return nTarget;
        else
        return pTarget;
            
    }    

    public int ThreeSumClosest(int[] nums, int target) {
       int n=nums.Length;
       int minAns=int.MaxValue;
       int result=0;
       Array.Sort(nums);
       for(int i=0;i<n-2;i++)
       {
           int left=i+1;
           int right=n-1;
           while(left<right)
           {
                int values=nums[i]+nums[left]+nums[right];
                int diffOfValAndTarget=Math.Abs(values-target);
                if(minAns>diffOfValAndTarget)
                {
                    result=values;
                    minAns=diffOfValAndTarget;
                }
                if(values>target)
                right--;
                else
                left++;
            }
       }
       return result;
    }
}