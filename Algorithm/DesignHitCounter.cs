using System.Reflection.Metadata;

public class HitCounter
{
    //Revise
    //System Design
    //VVIMP
    
    /*
    //Approach 1 not scallable
    private Queue<int> hits;

    public HitCounter()
    {
        hits = new Queue<int>();
    }

    public void RecordHit(int timestamp)
    {
        hits.Enqueue(timestamp);
    }

    public int GetHits(int timestamp)
    {
        int starttime = timestamp - 300;

        while(hits.Count > 0 && hits.Peek() <= starttime)
        {
            hits.Dequeue();
        }
        return hits.Count;
    }
    */

    //Approach 2 Scallable, keeps track of items in given time interval which here is 300 secs or 5 mins

    private int[] hits;
    private int[] times;
    private const int WINDOW_SIZE = 300;
    public HitCounter()
    {
        hits = new int[WINDOW_SIZE];
        times = new int[WINDOW_SIZE];
    }

    public void RecordHit(int timestamp)
    {
        int index = timestamp % WINDOW_SIZE; //get the index by mod of the time interval
        if(times[index] != timestamp) //if the new timestamp is not present at given index, update the index & hit with the new timestamp
        {
            times[index] = timestamp;
            hits[index] = 1;
        }
        else{
            hits[index]++; //else increment the hit. i.e multiple hits at same time.
        }
    }

    public int GetHits(int timestamp)
    {
        int totalHits = 0;
        for (int I = 0; I < WINDOW_SIZE; I++) //iterate over the array.
        {
            if(timestamp - times[I] < WINDOW_SIZE) //timestamp - time at index I, if it is smaller than window, count the hit & output.
            {
                totalHits += hits[I];
            }
        }
        return totalHits;
    }

}