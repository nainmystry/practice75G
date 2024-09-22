public class NonOverlapingIntervals
{
    public int EraseOverlapIntervals(int[][] intervals) {
        if(intervals.Length == 0 || intervals.Length == 1) return 0;

        //Array.Sort(intervals, new ComparerFirstIndex());
        Array.Sort(intervals, new ComparerSecondIndex());
        //Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

        int count = 0;
        int end = intervals[0][1];

        for (int I = 1; I < intervals.Length; I++)
        {
            //if start of interval is less than the end of prev one, increment cntr
            if(intervals[I][0] < end)
            count++;
            else
            end = intervals[I][1];
        }
        return count;
    }

    private class ComparerFirstIndex : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            return x[0].CompareTo(y[0]);
        }
    }

    private class ComparerSecondIndex : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            return x[1].CompareTo(y[1]);
        }
    }
}