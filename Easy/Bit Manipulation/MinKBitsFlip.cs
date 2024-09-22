public class MinKBitFlip {
    public int MinKBitFlips(int[] nums, int k) {
        int flips = 0;
        int mask = 1;
        for (int I = 0; I < nums.Length; I++)
        {
            if(nums[I] == 0)
            {                
                for (int II = 0; II < k; II++)
                {                    
                    if(I > nums.Length - 1){
                        flips = -1;
                        break;
                    }
                    else{
                    nums[I] = (nums[I] ^ mask);
                    flips++;
                    }
                    if(II < k - 1 && nums[I] != 0){
                        ++I;
                    }
                }            
            }

            if(flips == -1){
                break;
            }

            if(I == nums.Length - 1){
                int lastvalue = nums[nums.Length - 1];
                if(lastvalue == 0){
                    flips = -1;
                }
            }            

        } 
        Console.WriteLine(flips.ToString());
        return flips;
    }
}

