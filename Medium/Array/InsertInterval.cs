public class InsertInterval {
     public int[][] Insert(int[][] intervals, int[] newInterval) {
        try
        {
            List<int[]> result=new List<int[]>();
            int len=intervals.Length;            
            bool isAdded = false;
            for (int I = 0; I < len; I++)
            {              
                if(intervals[I][1]<newInterval[0] || newInterval[1]<intervals[I][0])
                {
                    if(!isAdded && newInterval[1]<intervals[I][0])
                    {
                        result.Add(newInterval);
                        isAdded=true;
                    }

                    result.Add(intervals[I]);
                }
                else{
                    newInterval[0]=Math.Min(newInterval[0], intervals[I][0]);
                    newInterval[1]=Math.Max(newInterval[1], intervals[I][1]);

                    if(!isAdded){
                        result.Add(newInterval);
                        isAdded=true;
                    }
                } 
            }

            if(!isAdded)
            {
                result.Add(newInterval);
                isAdded=true;
            }
            var res = result.ToArray();
            return res;
        }
        catch (System.Exception)
        {
            
            throw;
        }

    }

    public int[][] Insert2(int[][] intervals, int[] newInterval){
        var result = new List<int[]>();
        if (intervals.Length == 0)
        {
            result.Add(newInterval);
            return result.ToArray();
        }

        for (int i = 0; i < intervals.Length; i++)
        {
            if (newInterval == null)
            {
                result.Add(intervals[i]);
                continue;
            }

            var start = intervals[i][0];
            var end = intervals[i][1];

            if (start > newInterval[1])
            {
                result.Add(newInterval);
                result.Add(intervals[i]);
                newInterval = null;
                continue;
            }

            if (end < newInterval[0])
            {
                result.Add(intervals[i]);
                continue;
            }

            if (start < newInterval[0])
            {
                newInterval[0] = start;
            }
            if (end > newInterval[1])
            {
                newInterval[1] = end;
            }
        }

        if (newInterval != null)
        {
            result.Add(newInterval);
        }

        return result.ToArray();

    }
}