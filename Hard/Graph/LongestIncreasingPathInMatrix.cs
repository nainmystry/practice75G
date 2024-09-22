public class LongestIncreasingPathInMatrix
{

    /*
    Approach:
    DFS + Memoization: For each cell in the matrix, perform a DFS to explore all possible increasing paths. 
    Memoize the result for each cell so that it is not recalculated multiple times.
    Termination Condition: The DFS should terminate when you can't move to any neighboring cell with a higher value.
    Matrix Boundaries: Ensure you do not move out of the matrix boundaries or into a cell with a smaller or equal value.
    */
    int[,] memo ;
    private int[,] directions = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
    int rows, cols;
    public int LongestIncreasingPath(int[][] matrix) {
        rows = matrix.Length;
        cols = matrix[0].Length;
        int longestPath = 0;        
        memo = new int[rows,cols];

        for (int I = 0; I < rows; I++)
        {
            for (int J = 0; J < cols; J++)
            {
                longestPath = Math.Max(longestPath, DFS(matrix,I,J));   
            }            
        }
        return longestPath;
    }


    private int DFS(int[][] matrix, int row, int col)
    {
        if(memo[row, col] != 0)
        return memo[row, col];

        int maxPath = 1;

        for (int i = 0; i < 4; i++)
        {
            int newRow = row + directions[i, 0];
            int newCol = col + directions[i, 1];

            if(newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && matrix[newRow][newCol] > matrix[row][col])
            {
                int pathLength = 1 + DFS(matrix, newRow, newCol);
                maxPath = Math.Max(maxPath, pathLength);
            }
        }

        memo[row,col] = maxPath;
        return maxPath; 

    }
}