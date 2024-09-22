public class SolutionWC
{
    public double MinimumAverage(int[] nums) {
        double average = double.MaxValue;
        if(nums == null || nums.Length == 0)
            return 0;
        
        Array.Sort(nums);
        int l = 0, r = nums.Length - 1;
        while(l < r)
        {
            var minelement = nums[l];
            var maxelement = nums[r];

            double avr = (double) (minelement + maxelement) / 2;

            if(avr < average)
            {
                average = avr;
            }
            l++;
            r--;
        }
       return average;
    }

    public int MinimumArea(int[][] grid) {
        if(grid == null || grid.Length == 0)
            return 0;

        int area = 0;
        int rows = grid.Length, cols = grid[0].Length;
        int maxH = 0, maxW = 0;
        HashSet<int> colsW = new HashSet<int>();
        HashSet<int> rowsH = new HashSet<int>();
        for (int I = 0; I < rows; I++)
        {
            bool oneExist = false;
            for (int II = 0; II < cols; II++)
            {
                if(grid[I][II] == 1)
                {
                    oneExist = true;
                    if(maxW < II + 1)
                    {
                        maxW = II + 1;
                        colsW.Add(II + 1);
                    }
                }
            }
            if(oneExist)
            {
                rowsH.Add(I);
            }
        }
        maxH = rowsH.Count;
        maxW = colsW.Count;
        if(maxH != 0 && maxW != 0)
        {
            area = maxH * maxW;
        }
        return area;
    }


}