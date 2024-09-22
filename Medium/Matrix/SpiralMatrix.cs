public class SpiralMatrix
{
    public IList<int> SpiralOrder(int[][] matrix) {
        var result = new List<int>();

        if(matrix == null || matrix.Length == 0) return result;

        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int top = 0, bottom = rows - 1;
        int left = 0, right = cols - 1;

        while(top <= bottom && left <= right)
        {
            //travering from left -> right from top row
            for (int I = left; I <= right; I++)
            {
                result.Add(matrix[top][I]);
            }
            top++;

            //traversing top -> bottom from right most column
            for (int I = top; I <= bottom; I++)
            {
                result.Add(matrix[I][right]);
            }
            right--;

            if(top <= bottom)
            {
                //traverse right to left, from last row.
                for (int I = right; I >= left; I--) {
                    result.Add(matrix[bottom][I]);
                }
                bottom--;
            }

               // Check if there are still columns to traverse
            if (left <= right) {
                // Traverse from bottom to top along the left column
                for (int I = bottom; I >= top; I--) {
                    result.Add(matrix[I][left]);
                }
                left++;
            }
        }

        return result;
    }
}