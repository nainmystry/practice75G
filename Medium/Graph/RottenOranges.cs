using System.Collections;
using System.Runtime.InteropServices;

public class RottenOranges {

    private int minEllapsed = 0;
    private int freshOranges = 0;
    public int OrangesRotting1(int[][] grid) {
        if(grid == null || grid.Length == 0){
            return 0;
        }
        int rows = grid.Length;
        int cols = grid[0].Length;
        int[][] directions = new int[][]
        {
            
            new int[] {0, -1}, //left
            new int[] {1, 0}, //down               
            new int[] {0, 1}, //right
            new int[] {-1, 0} //up
        };
        bool firstfresh = false;
        if(grid[0][0] == 1){
            firstfresh = true;
        }
        for (int I = 0; I < rows; I++)
        {
            for (int II = 0; II < cols; II++)
            {
                if(grid[I][II] == 1)
                {
                    freshOranges++;
                }
                if(grid[I][II] == 2)
                {
                    BFS1(grid, I, II, directions);
                }
            }
        }

        if(firstfresh && grid[0][0] == 2 && cols > 1){
            freshOranges--;
        }

        if(freshOranges > 0) return -1;
        else{
            return minEllapsed > 1 ? --minEllapsed : 0;
        }
    }

    private void BFS1(int[][] grid, int I, int II, int[][] directions)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        Queue<int[]> q = new Queue<int[]>();
        q.Enqueue(new int[]{I, II});
        
        while(q.Count > 0)
        {
            bool anyRotten = false;
            int[] cell = q.Dequeue();
            int row = cell[0];
            int col = cell[1];            
            
            foreach (var direction in directions)
            {
                int newrow = row + direction[0];
                int newcol = col + direction[1];

                if(newrow >= 0 && newrow < rows && newcol >= 0 && newcol < cols && grid[newrow][newcol] == 1)
                {
                    freshOranges++;
                    q.Enqueue(new int[]{newrow, newcol});
                    grid[newrow][newcol] = 2;
                    anyRotten = true;
                    freshOranges--;
                }
            }

            if(anyRotten){
                minEllapsed++;
            }
        }

    }


    public int OrangesRotting(int[][] grid)
    {
        if(grid == null || grid.Length == 0)
            return 0;

        int rows = grid.Length;
        int cols = grid[0].Length;
        int[][] directions = new int[][]
        {
            
            new int[] {0, -1}, //left
            new int[] {1, 0}, //down               
            new int[] {0, 1}, //right
            new int[] {-1, 0} //up
        };

        Queue<int[]> rottenOranges = new Queue<int[]>();
        for (int I = 0; I < rows; I++)
        {
            for (int II = 0; II < cols; II++)
            {
                if(grid[I][II] == 1)
                {
                    freshOranges++;
                }
                if(grid[I][II] == 2)
                {
                    rottenOranges.Enqueue(new int[] {I, II});
                }
            }
        }
        if(freshOranges == 0) return 0;
        int countmin = 0, cnt = 0;
        while(rottenOranges.Count > 0)
        {
            int count = rottenOranges.Count;
            // cnt += count;

            for (int I = 0; I < count; I++)
            {
                int[] arr = rottenOranges.Dequeue();
                foreach (var direction in directions)
                {
                    int newrow = arr[0] + direction[0];
                    int newcol = arr[1] + direction[1];

                    if(newrow < 0 || newcol < 0 || newrow >= rows ||  newcol >= cols ||
                     grid[newrow][newcol] == 0 || grid[newrow][newcol] == 2)
                    {
                        continue;
                    }

                    grid[newrow][newcol] = 2;
                    rottenOranges.Enqueue(new int[]{newrow, newcol});
                    cnt++;
                }                
            }

            if(rottenOranges.Count != 0){
                countmin++;
            }
        }
        return freshOranges == cnt ? countmin : -1;
    }
}