public class MedianFinder1
{
    PriorityQueue<int, int> max = new PriorityQueue<int,int>(Comparer<int>.Create((a,b)=>b-a));
    PriorityQueue<int, int> min = new();
    public MedianFinder1() {
        
    }
    
    public void AddNum(int num) {
        max.Enqueue(num, num);
        min.Enqueue(max.Peek(),max.Peek());
        max.Dequeue();
        if(min.Count>max.Count)
        {
            max.Enqueue(min.Peek(),min.Peek());
            min.Dequeue();
        }
    }
    
    public double FindMedian() {
        if((max.Count+min.Count)%2==1)
        {
            return max.Peek();
        }
        else
        {
            return (double)(max.Peek()+min.Peek())/2;
        }
    }
}


public class MedianFinder {
    private int[] count;
    private int totalNumbers;

    public MedianFinder() {
        count = new int[101];
        totalNumbers = 0;
    }

    public void AddNum(int num) {
        count[num]++;
        totalNumbers++;
    }

    public double FindMedian() {
        int middle1 = (totalNumbers + 1) / 2;
        int middle2 = (totalNumbers + 2) / 2;

        int cumulativeCount = 0;
        int median1 = 0, median2 = 0;

        for (int i = 0; i < count.Length; i++) {
            cumulativeCount += count[i];

            if (cumulativeCount >= middle1 && median1 == 0) {
                median1 = i;
            }

            if (cumulativeCount >= middle2) {
                median2 = i;
                break;
            }
        }

        return (median1 + median2) / 2.0;
    }
}
