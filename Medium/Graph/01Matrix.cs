public class Matrix_MinDistance
{
    #region dump incomplete code
    Queue<int[]> values = new Queue<int[]>();
    public int[][] UpdateMatrix(int[][] tDMat, int i) {
        
        int rows = tDMat.Length;
        int cols = tDMat[0].Length;
        int[][] newAr = new int[rows][];        
        for (int I = 0; I < rows; I++)
        {
            newAr[I] = new int[tDMat[I].Length];            
        }
        for (int I = 0; I < rows; I++)
        {
            for (int II = 0; II < cols; II++)
            {
                if(tDMat[I][II] != 0){
                    newAr[I][II] = updateIndex(I,II,newAr);
                }
            }
        }
        var res = newAr;
        return res;
    }

    private int updateIndex(int row, int col, int[][] updateArr){
        try{
            bool leftValue = false, rightValue= false, downValue= false, upValue = false;
            int minValue = 0;            
            
            while(leftValue || rightValue || downValue || upValue){
                minValue++;
                leftValue = valueExists(row,col - 1,updateArr);
                if(leftValue){
                    var leftVal = updateArr[row][col-1] + 1;
                    minValue = Math.Min(minValue, leftVal); 
                    break;
                }
                rightValue = valueExists(row,col + 1,updateArr);
                if(rightValue){
                    var rightVal = updateArr[row][col+1] + 1; 
                    minValue = Math.Min(minValue, rightVal);
                    break;
                }
                upValue = valueExists(row - 1,col,updateArr);
                if(upValue){
                    var upVal = updateArr[row-1][col] + 1; 
                    minValue = Math.Min(minValue, upVal);
                    break;
                }            
                downValue = valueExists(row + 1,col,updateArr);
                if(downValue){
                    var downVal = updateArr[row+1][col] + 1; 
                    minValue = Math.Min(minValue, downVal);
                    break;
                }
            }
            return minValue;
        }
        catch(Exception ex){
            throw;
        }
    }

    private bool valueExists(int row, int col, int[][] updateArr){
        if(row >= updateArr.Length || row < 0 || col < 0 || col > updateArr[row].Length){
            return false;
        }        

        if(updateArr[row][col] == 0){
            return true;
        }
        else{
            return true;
        }
    }
    #endregion

    public int[][] UpdateMatrix(int[][] mat){
         if (mat == null || mat.Length == 0 || mat[0].Length == 0)
            return new int[0][];

        int m = mat.Length, n = mat[0].Length;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        int MAX_VALUE = m * n;
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 0) {
                    queue.Enqueue((i, j));
                } else {
                    mat[i][j] = MAX_VALUE;
                }
            }
        }
        
        (int, int)[] directions = {(1, 0), (-1, 0), (0, 1), (0, -1)};
        
        while (queue.Count > 0) {
            (int row, int col) = queue.Dequeue();
            foreach (var (dr, dc) in directions) {
                int r = row + dr, c = col + dc;
                if (r >= 0 && r < m && c >= 0 && c < n && mat[r][c] > mat[row][col] + 1) {
                    queue.Enqueue((r, c));
                    mat[r][c] = mat[row][col] + 1;
                }
            }
        }
        
        return mat;
    }
}