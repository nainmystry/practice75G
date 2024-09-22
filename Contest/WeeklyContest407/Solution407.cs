using System.IO.IsolatedStorage;

public class Solution407
{
    //Number of Bit Changes to Make 2 number equal.

    /*
    Explanation
    Check Feasibility: First, we need to check if it is possible to convert n to k. 
            This is only possible if all the bits set to 1 in k are also set to 1 in n. In other words, k should be a subset of n when considering the bits that are 1.
    Count Changes: If it is possible to convert n to k, count how many bits set to 1 in n are not set to 1 in k. 
            These are the bits that need to be changed from 1 to 0.

    Steps to Solve
    -   Perform a bitwise AND between n and k. 
        If the result is not equal to k, return -1.
    -   Count the number of 1's in n that are not in k.
    */
    public int MinChanges(int n, int k) {
        // Check if all bits set in k are also set in n
        if((n & k) != k)
        {
            return -1;
        }

        int updateBits = 0;
        // Count bits set in n but not in k
        for (int I = 0; I < 32; I++)
        {
            int nBits = (n >> I) & 1;
            int kBits = (k >> I) & 1;
            if(nBits == 1 && kBits == 0)
            {
                updateBits++;
            }
        }
        return updateBits;
    }

    //Vowels Game in String
    /*
        Alice always wins if there is at least one vowel. 
        So if a vowel is found, then return true.
        Else Bob wins.
    */
    public bool DoesAliceWin(string s) {
        HashSet<char> v = new(){'a','e','i','o','u'};
        foreach(char c in s)
            if(v.Contains(c)) return true;
        return false;
    }

    //Maximum Number of Operations To Move One to End
    public int MaxOperations(string s) {
        int result=0;
        int zeros = 0;
        for(int i=s.Length-1; i>=0; i--)
        {
            if(s[i]=='1') result+=(zeros);
            else
            {
                if(i==s.Length-1 || s[i+1]!='0') zeros++;
            }
        }
        return result;
    }

    public int MaxOperations2(string s) {
        int count = 0, prev = 0;

        for (var i = s.Length - 2; i >= 0; i--) {
            if (s[i] == '1') {
                prev = (s[i + 1] == '0') ? prev + 1 : prev;
                count += prev;
            }
        }

        return count;
    }

    // Minimum Operations to Make Array Equal to Target
    /*
    Start from the leftmost element of the array and calculate the required increment or decrement needed to match the target for the first element.
    Track Increments and Decrements:
        For each subsequent element, check if the current increment/decrement operations are sufficient to match the target. If not, increase the number of operations needed and adjust the current count of increments or decrements.
        Keep track of how many increments or decrements are being applied as you traverse through the array.
    Switch Between Increments and Decrements:
        If you switch from incrementing to decrementing (or vice versa), reset the respective operation counter because the new operation will be independent of the previous one.
    Count Operations:
        At the end of the traversal, the total number of operations performed will be the result.

    */
    public long MinimumOperationsv1(int[] nums, int[] target) {
        int n = nums.Length;
        int totalOperations = 0;
        int currentIncrement = 0;
        int currentDecrement = 0;
        
        // Traverse through each element
        for (int i = 0; i < n; i++)
        {
            int required = target[i] - nums[i];
            
            if (required > 0) {
                if (currentIncrement < required)
                    totalOperations += required - currentIncrement;
                currentIncrement = required;
                currentDecrement = 0;
            } else if (required < 0) {
                if (currentDecrement < -required)
                    totalOperations += -required - currentDecrement;
                currentDecrement = -required;
                currentIncrement = 0;
            } else {
                currentIncrement = currentDecrement = 0;
            }
        }
        
        return totalOperations;
    }
    public long MinimumOperations(int[] nums, int[] target) {
        int n = nums.Length;
        int totalOperations = 0;
        int currentIncrement = 0;
        int currentDecrement = 0;
        
        // Traverse through each element
        for (int i = 0; i < n; i++)
        {
            int required = target[i] - nums[i];
            
            if (currentIncrement < required)
            {
                // We need more increments
                totalOperations += required - currentIncrement;
                currentIncrement = required;
                currentDecrement = 0; // Reset decrement counter
            }
            else if (currentDecrement < -required)
            {
                // We need more decrements
                totalOperations += -required - currentDecrement;
                currentDecrement = -required;
                currentIncrement = 0; // Reset increment counter
            }
            else
            {
                // No additional increments or decrements needed
                currentIncrement = required > 0 ? required : 0;
                currentDecrement = required < 0 ? -required : 0;
            }
        }
        
        return totalOperations;
    }
}