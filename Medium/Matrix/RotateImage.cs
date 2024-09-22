public class RotateImage
{
    //Approach 1
    public void Rotate90(int[][] matrix) {
        if(matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        {
            return;
        }  
        int rows = matrix.Length, cols = matrix[0].Length; 
        for (int I = 0; I < rows / 2; I++)
        {
            for (int II = I; II < rows - I - 1; II++)
            {
                //top element
                int temp = matrix[I][II];

                //move left to top
                matrix[I][II] = matrix[rows - II - 1][I];

                //move bottom to left
                matrix[rows - II - 1][I] = matrix[rows - I - 1][rows - II - 1];

                //move right to bottom
                matrix[rows - I - 1][rows - II - 1] = matrix[II][rows - I - 1];

                // Assign temp to right
                matrix[II][rows - I - 1] = temp;
            }
        }
        var res = "";
    }

    //Approach 2
    /*
    step 1 - Transpose the matrix
    step 2 rotate the rows
    */
    public void Rotate90V2(int[][] matrix)
    {
        int n = matrix.Length;

        for (int I = 0; I < n; I++)
        {
            for (int II = I + 1; II < n; II++)
            {
                int temp = matrix[I][II];
                matrix[I][II] = matrix[II][I];
                matrix[II][I] = temp;
            }            
        }

        for (int I = 0; I < n; I++)
        {
            Array.Reverse(matrix[I]);
        }
        var res = "";
    }

    public void Rotate180(int[][] matrix)
    {
        int n = matrix.Length;

        for (int I = 0; I < n / 2; I++)
        {
            for (int II = 0; II < n; II++)
            {
                int temp = matrix[I][II];
                matrix[I][II] = matrix[n - 1 - I][n - 1 - II];
                matrix[n - 1 - I][n - 1 - II] = temp;
            }
        }

        if(n % 2 != 0)
        {
            int mid = n / 2;
            for (int I = 0; I < n / 2; I++)
            {
                int temp = matrix[mid][I];
                matrix[mid][I] = matrix[mid][n - 1 - I];
                matrix[mid][n - 1 - I] = temp; 
            }
        }
        
        var res = "";
    }
}