class ShortestPathToFoodBFS
{
    //VVIMP
    static int GetShortestPathToFood(char[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        
        (int, int)[] directions = { (0, 1), (1, 0), (0, -1), (-1, 0) };

        Queue<(int, int)> queue = new Queue<(int, int)>();
        bool[,] visited = new bool[rows, cols];

        // Find the starting point 'S'
        for (int I = 0; I < rows; I++)
        {
            for (int II = 0; II < cols; II++)
            {
                if(grid[I][II] == 'S')
                {
                    queue.Enqueue((I,II));
                    visited[I,II] = true;
                    break;
                }
            }
        }

        int pathLength = 0;
        while(queue.Count > 0)
        {
            int count = queue.Count;
            for (int III = 0; III < count; III++)
            {
                var (currRow, currCol) = queue.Dequeue();

                if(grid[currRow][currCol] == 'F')
                {
                    return pathLength;
                }

                foreach (var (dr,dc) in directions)
                {
                    int newRow = currRow + dr;
                    int newCol = currCol + dc;

                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && !visited[newRow, newCol] && grid[newRow][newCol] != 'O')
                    {
                        queue.Enqueue((newRow, newCol));
                        visited[newRow, newCol] = true;
                    }
                }
            }
            pathLength++;
        }
        return -1; // Path to food not found
    }
}


public class ShortestPathToFood
{
    

    private bool DFS(int[][] matrix, int row, int col)
    {

        var dir = new int[][]
        {
            new int[] {-1,0},
            new int[] {0, -1},
            new int[] {1, 0},
            new int[] {0, 1},
        };

        for (int i = 0; i < 4; i++)
        {
            int newRow = row + dir[i][0];
            int newCol = row + dir[i][1];

            if(newRow >= 0 || newRow < matrix.Length || newCol >= 0 || newCol < matrix[0].Length ||
            matrix[newRow][newCol] == '.' || matrix[newRow][newCol] == 'F')
            {
                if(matrix[newRow][newCol] == '.')
                {
                    DFS(matrix, newRow, newCol);
                }
                else{
                    return true;
                }
            }
        }

        return false;
    }
}