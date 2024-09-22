public class MeetingRoomsII
{
    //VVIMP
    public int MinMeetingRooms(int[][] intervals) 
    {
       if (intervals == null || intervals.Length == 0) return 0;

        // Sort the intervals by start time
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        // Min-heap to keep track of the end times of meetings
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        // Add the end time of the first meeting
        minHeap.Enqueue(intervals[0][1], intervals[0][1]);

        for (int i = 1; i < intervals.Length; i++)
        {
            // Check if the earliest ending meeting has ended
            if (intervals[i][0] >= minHeap.Peek()) {
                minHeap.Dequeue(); // Remove the room (meeting has ended)
            }
            // Add the current meeting's end time to the heap
            minHeap.Enqueue(intervals[i][1], intervals[i][1]);
        }

        // The number of rooms required is the size of the heap
        return minHeap.Count;
    }
}