public class NumOfIslands {
    public int NumIslandsWithDFS(char[][] grid) {
        int islandCount = 0;
        int m = grid.Length;
        int n = grid[0].Length;
        for (int I = 0; I < m; I++)
        {
            for (int II = 0; II < n; II++)
            {
                if(grid[I][II] == '1'){
                    islandCount++;
                    DFS(grid, I, II);
                }
            }
        }

        return islandCount;
    }

    private void DFS(char[][] grid, int i, int j)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        if(i < 0 || i >= rows || j < 0 || j >= cols || grid[i][j] == '0')
        {
            return;
        }

        //Mark visited cell as 0
        grid[i][j] = '0';

        // Visit all 4 adjacent cells (up, down, left, right)
        DFS(grid, i + 1, j); // down
        DFS(grid, i - 1, j); // up
        DFS(grid, i, j + 1); // right
        DFS(grid, i, j - 1); // left
    }

    public int NumIslands(char[][] grid){
        int islandCount = 0;
        if(grid == null || grid.Length == 0){
         return islandCount;
        }   

        int rows = grid.Length;
        int cols = grid[0].Length;
        int[][] directions = new int[][]
        {
            new int[] {1, 0}, // down
            new int[] {-1, 0}, // up
            new int[] {0, 1}, // right
            new int[] {0, -1} // left
        };

        for (int I = 0; I < rows; I++)
        {
            for (int II = 0; II < cols; II++)
            {
                if (grid[I][II] == '1')
                {
                    islandCount++;
                    BFS(grid, I, II, directions);
                }
            }
        }
        return islandCount;
    }

    private void BFS(char[][] grid, int I, int II, int[][] directions)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[]{I, II});
        grid[I][II] = '0'; //visited

        while(queue.Count > 0)
        {
            int[] cell = queue.Dequeue();
            int row = cell[0];
            int col = cell[1];

            foreach (int[] direction in directions)
            {
                int newrow = row + direction[0];
                int newcol = col + direction[1];

                if(newrow >= 0 && newrow < rows && newcol >= 0 && newcol < cols && grid[newrow][newcol] == '1')
                {
                    queue.Enqueue(new int[] { newrow, newcol });
                    grid[newrow][newcol] = '0';
                }

            }
        }
    }
}