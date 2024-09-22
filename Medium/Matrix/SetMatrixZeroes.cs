public class SetMatrixZeroes
{
    public void SetZeroes(int[][] matrix) {
        List<int[]> zeroesIndex = new List<int[]>();

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int ii = 0; ii < matrix[0].Length; ii++)
            {
                if(matrix[i][ii] == 0)
                {
                    zeroesIndex.Add(new int[] {i,ii});
                }
            }
        }
        HashSet<int> zeroedRows = new HashSet<int>();
        HashSet<int> zeroedCols = new HashSet<int>();
        for (int I = 0; I < zeroesIndex.Count; I++)
        {
            var intArr = zeroesIndex[I];
            int row = intArr[0], col = intArr[1];
            
            if(!zeroedCols.Contains(col))
            {
                var j = 0;
                while(j < matrix.Length)
                {
                    matrix[j][col] = 0;
                    j++;
                }
            }

            if(!zeroedRows.Contains(row))
            {
                var j = 0;
                while(j < matrix[0].Length)
                {
                    matrix[row][j] = 0;
                    j++;
                }
            }

            zeroedRows.Add(row);zeroedCols.Add(col);            
        }
    }
}