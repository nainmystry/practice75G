public class JobSchedulings
{
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit) {
        if(startTime == null || startTime.Length == 0)
        return 0;

        var jobs = new List<Job>();
        for (int I = 0; I < startTime.Length; I++)
        {
            jobs.Add(new Job(startTime[I], endTime[I], profit[I]));            
        }

        jobs.Sort((a,b) => a.startTime - b.startTime);

        return DFS(jobs, 0, new Dictionary<int, int>());

    }

    private int DFS(List<Job> jobs, int currentJobIndex, Dictionary<int,int> maxProfits)
    {
        if(currentJobIndex >= jobs.Count)
        return 0;

        if(maxProfits.ContainsKey(currentJobIndex))
        {
            return maxProfits[currentJobIndex];
        }

        int next = BinarySearch(jobs, currentJobIndex);
        int inc = jobs[currentJobIndex].profit + (next == -1 ? 0 : DFS(jobs, next, maxProfits));
        int exc = DFS(jobs, currentJobIndex + 1, maxProfits);

        int maxProfit = Math.Max(inc, exc);
        maxProfits[currentJobIndex] =  maxProfit;
        return maxProfit;
    }

    private int BinarySearch(List<Job> jobs, int currentIndex)
    {
        int lo = currentIndex;
        int hi = jobs.Count - 1;
        int result = -1;
        while(lo <= hi)
        {
            int mid = lo + (hi - lo) / 2;
            if(jobs[currentIndex].endTime <= jobs[mid].startTime)
            {
                result = mid;
                hi = mid - 1;
            }
            else{
                lo = mid + 1;
            }
        }
        return result;
    }

    record Job(int startTime, int endTime, int profit);


    public int JobScheduling1(int[] startTime, int[] endTime, int[] profit)
    {
        int n = startTime.Length;
        Job[] jobs = new Job[n];
        
        // Creating job records
        for (int i = 0; i < n; i++)
        {
            jobs[i] = new Job(startTime[i], endTime[i], profit[i]);
        }
        
        // Sorting jobs by end time
        Array.Sort(jobs, (a, b) => a.endTime.CompareTo(b.endTime));

        // DP array to store maximum profit until job i
        int[] dp = new int[n];
        dp[0] = jobs[0].profit;
        
        for (int i = 1; i < n; i++)
        {
            // Include current job
            int includeProfit = jobs[i].profit;
            
            // Find the last job that doesn't overlap
            int l = -1;
            for (int j = i - 1; j >= 0; j--)
            {
                if (jobs[j].endTime <= jobs[i].startTime)
                {
                    l = j;
                    break;
                }
            }
            
            if (l != -1)
            {
                includeProfit += dp[l];
            }
            
            // Max profit is the max of including or excluding the job
            dp[i] = Math.Max(includeProfit, dp[i - 1]);
        }
        
        return dp[n - 1];
    }

    public int JobScheduling2(int[] startTime, int[] endTime, int[] profit) {
        int n = startTime.Length;
        List<Job> jobs = new List<Job>();
        
        for (int i = 0; i < n; i++) {
            jobs.Add(new Job(startTime[i], endTime[i], profit[i]));
        }
        
        jobs.Sort((x, y) => x.endTime.CompareTo(y.endTime));
        
        int[] dp = new int[n + 1];
        
        for (int i = 1; i <= n; i++) {
            dp[i] = Math.Max(dp[i - 1], jobs[i - 1].profit);
            for (int j = i - 1; j > 0; j--) {
                if (jobs[i - 1].startTime >= jobs[j - 1].endTime) {
                    dp[i] = Math.Max(dp[i], dp[j] + jobs[i - 1].profit);
                    break;
                }
            }
        }
        
        return dp[n];
    }
}