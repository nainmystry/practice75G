
//Rare
//Floyd's Tortoise and Hare (Cycle Detection) algorithm
public class FindDuplicateNumber
{
    public int FindDuplicate(int[] nums)
    {
        // Step 1: Initialize two pointers, both starting at the first element
        int tortoise = nums[0];
        int hare = nums[0];
        
        // Step 2: Move tortoise one step and hare two steps until they meet
        do {
            tortoise = nums[tortoise];
            hare = nums[nums[hare]]; //this wont give index error since input Array is guaranteed to be between 1 and n.
        } while (tortoise != hare);
        
        // Step 3: Reset one pointer to the start
        tortoise = nums[0];
        
        // Step 4: Move both pointers one step at a time until they meet again
        while (tortoise != hare) {
            tortoise = nums[tortoise];
            hare = nums[hare];
        }
        
        // Step 5: Return the meeting point which is the duplicate number
        return hare;
    }
}