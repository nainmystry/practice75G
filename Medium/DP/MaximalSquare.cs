public class MaximalSquares
{
    public int MaximalSquare(char[][] matrix) {

        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        {
            return 0;
        }
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int[,] dpArray = new int[rows,cols];

        int maxSide = 0;

        for (int I = 0; I < rows; I++)
        {
            for (int II = 0; II < cols; II++)
            {
                if(matrix[I][II] == '1')
                {
                    if(I == 0 || II == 0)
                    {
                        dpArray[I,II] = 1;
                    }
                    else{
                         dpArray[I,II] = Math.Min(dpArray[I-1,II], Math.Min(dpArray[I,II-1], dpArray[I-1,II-1])) + 1;
                    }
                    maxSide = Math.Max(maxSide, dpArray[I,II]);
                }
            }
        }
        return maxSide * maxSide;
    }
}