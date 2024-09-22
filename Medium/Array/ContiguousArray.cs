public class ContiguousArray
{
    //Revise
    //The prefix sum and hash map approach
    public int FindMaxLength(int[] nums) 
    {
        Dictionary<int, int> map = new();
        int max = 0;
        int n = nums.Length;
        int sum = 0;
        map[0] = -1;
        for(int i = 0; i < n; i++) {
            sum += (nums[i] == 1 ? 1 : -1);
            //add the sum in map, if sum exists in map, then subtract the (index) stored as value with current index. 
            if(map.ContainsKey(sum))
            {
                var subArrayLength = i - map[sum]; 
                max = Math.Max(max, subArrayLength);
            }           
            else
                map[sum] = i;
        }
        return max;   
    }
}