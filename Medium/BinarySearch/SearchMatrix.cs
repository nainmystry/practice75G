public class Search2DMatrix
{
    //Binary Search
    //Approach 1 Easy
    //m*logn Time 
    public bool SearchMatrix1(int[][] matrix, int target) {
        if(matrix.Length == 0) return false;

        List<int> bsSet = new List<int>();
        int rowIndex = 0;
        for (int I = 0; I < matrix.Length; I++)
        {            
            if(matrix[I][0] > target)
            break;

            rowIndex = I;
        }
        if(rowIndex < 0) return false;        
        int min = 0, max = matrix[rowIndex].Length - 1;
        while(min <= max)
        {
            int mid = min + (max - min) / 2;
            if(matrix[rowIndex][mid] == target)
            return true;
            else if(matrix[rowIndex][mid] < target)
            min = mid + 1;
            else
            max = mid - 1;
        }
        return false;
    }

    //Approach 2 Optimised
    //since the array is sorted, we can consider the whole matrix as one array.
    //log(m*n)
    public bool SearchMatrix(int[][] matrix, int target) {
        int cols = matrix[0].Length;
        int left = 0;
        int right = matrix.Length * cols - 1;
        int mid, midRow, midCol;
        while (left <= right)
        {
            mid = (right-left)/2 + left;
            midRow = mid/cols;
            midCol = mid % cols;
            if (matrix[midRow][midCol] == target)
            return true;
            else if (left == right)
            return false;
            else if (matrix[midRow][midCol] > target)
            {
                right = mid;
            }
            else
            {
                left = mid+1;
            }
        } 
        return false;
    }
}