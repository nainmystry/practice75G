class ThreeSumClass
{

    /*
    use 3 pointer's- start, left, right 
    set target, keep sliding left & right indexes
    */
    //Two Pointers
    public IList<IList<int>> ThreeSum(int[] nums) {
        var result = new List<IList<int>>();
        
        if(nums.Length <= 2) return result;

        Array.Sort(nums);
        
        int start = 0, left, right;
        int target;
        int N = nums.Length;
        while(start < N - 2){
            target = nums[start] * -1;
            left = start + 1;
            right = N - 1;
            
            while(left < right){
                //if total is greater than sum, decrement right <- shift
                if(nums[left] + nums[right] > target){
                    --right;
                }
                //if total is less than sum, increment left -> 
                else if(nums[left] + nums[right] < target){
                    ++left;
                }
                //if total is equal to sum, save the triplets.
                else{
                    List<int> OneSolution = new List<int>() { nums[start], nums[left], nums[right] };
                        result.Add(OneSolution);

                        //check the next left index, if it is same as current left, increment
                        while (left < right && nums[left] == OneSolution[1])
                            ++left;
                        //check the next right index, if it same as current right, decrement
                        while (left < right && nums[right] == OneSolution[2])
                            --right;
                }
            }
            int currentStartNumber = nums[start];
            
            //Increment the start counter,  if the start number is same as current start, keep incrementing
            while (start < nums.Length - 2 && nums[start] == currentStartNumber) 
                ++start;
        }
        return result;

    }
}