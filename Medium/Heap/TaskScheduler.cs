public class TaskScheduler
{
    //Revise Task Arrangement & Gap Concepts, Task Scheduler, Frequency Analysis
    public int LeastInterval1(char[] tasks, int n) {
        // Step 1: Count the frequency of each task
        int[] frequencies = new int[26];
        foreach (char task in tasks) {
            frequencies[task - 'A']++;
        }
        
        // Step 2: Use a max heap to store tasks by their frequency
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
        foreach (int frequency in frequencies) {
            if (frequency > 0) {
                maxHeap.Enqueue(frequency, frequency);
            }
        }

        // Step 3: Simulate the process of task scheduling
        int intervals = 0;
        Queue<(int, int)> cooldownQueue = new Queue<(int, int)>();
        
        while (maxHeap.Count > 0 || cooldownQueue.Count > 0) {
            intervals++;
            
            if (maxHeap.Count > 0) {
                int currentTaskFreq = maxHeap.Dequeue() - 1;
                if (currentTaskFreq > 0) {
                    cooldownQueue.Enqueue((currentTaskFreq, intervals + n));
                }
            }
            
            if (cooldownQueue.Count > 0 && cooldownQueue.Peek().Item2 == intervals) {
                var itesms = cooldownQueue.Dequeue();
                maxHeap.Enqueue(itesms.Item1, itesms.Item1);
            }
        }
        
        return intervals;
    }

    public int LeastInterval2(char[] tasks, int n) {
        int[] frequencies = new int[26];
        foreach (char task in tasks) {
            frequencies[task - 'A']++;
        }
        
        Array.Sort(frequencies);
        
        int maxFrequency = frequencies[25] - 1;
        int idleSlots = maxFrequency * n;
        
        for (int i = 24; i >= 0 && frequencies[i] > 0; i--) {
            idleSlots -= Math.Min(frequencies[i], maxFrequency);
        }
        
        return Math.Max(idleSlots, 0) + tasks.Length;
    }

    public int LeastInterval(char[] tasks, int n) {
        int[] freq = new int[26];
        int max = 0;
        int maxCount = 0;
        foreach (char task in tasks) {
            freq[task - 'A']++;
            if (max == freq[task - 'A']) {
                maxCount++;
            } else if (max < freq[task - 'A']) {
                max = freq[task - 'A'];
                maxCount = 1;
            }
        }

        int gapCount = max - 1;
        int gapLength = n - (maxCount - 1);
        int empty = gapCount * gapLength;
        int availableTasks = tasks.Length - max * maxCount;
        int idles = Math.Max(0, empty - availableTasks);

        return tasks.Length + idles;
    }
}
