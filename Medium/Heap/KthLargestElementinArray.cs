public class KthLargestElementinArray
{
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        foreach(var num in nums)
        {
            minHeap.Enqueue(num, num); /*The current element itslef serves as a priorty in minHeap along with its value*/
            
            /*Ensures that we don't have more than k element in our priorty queue so the minimum element alway stays on top, In this question the top element will always be kth largest element*/
            if(minHeap.Count > k) 
                minHeap.Dequeue();
        }   
        /*peek element is always kth largest element*/
        return minHeap.Peek();
    }
}