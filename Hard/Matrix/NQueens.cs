using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

public class NQueens
{
    //Matrix + recursion

    public IList<IList<string>> SolveNQueens(int n) {
        char[][] board = new char[n][];

        for (int I = 0; I < n; I++)
        {
            board[I] = new char[n];
            for (int II = 0; II < n; II++)
            {
                board[I][II] = '.';
            }
        }

        HashSet<int> cols = new HashSet<int>();
        HashSet<int> posDiag = new HashSet<int>();
        HashSet<int> negDiag = new HashSet<int>();
        List<IList<string>> ans = new List<IList<string>>();
        void Backtrack(int row)
        {
            if(row == n)
            {
                List<string> strArr = new List<string>();
                for (int I = 0; I < n; I++)
                {
                    var str = new string(board[I]);
                    strArr.Add(str);
                }
                ans.Add(strArr);
            }

            for (int col = 0; col < n; col++)
            {
                if(cols.Contains(col) ||
                    negDiag.Contains(row - col) ||
                    posDiag.Contains(row + col))
                    {
                        continue;
                    }

                cols.Add(col);
                negDiag.Add(row - col);
                posDiag.Add(row + col);
                board[row][col] = 'Q';
                Backtrack(row + 1);
                board[row][col] = '.';
                cols.Remove(col);
                negDiag.Remove(row - col);
                posDiag.Remove(row + col);
            }
        }    

        Backtrack(0);
        return ans;    
    }    
}