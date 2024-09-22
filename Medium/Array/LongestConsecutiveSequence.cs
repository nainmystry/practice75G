using System.Dynamic;

public class LongestConsecutiveSequence
{
    public int LongestConsecutive(int[] nums) {
        HashSet<int> numHash= new HashSet<int>(nums);
        int maxlength = 0;
        foreach (int num in numHash)
        {
            if(numHash.Contains(num -1)) continue;
            
            int length = 0;
            while(numHash.Contains(num + length))
            {
                length++;
            }
            maxlength = Math.Max(maxlength, length);
        }

        return maxlength;
    }
}