using System.Reflection;

public class WordSearch
{
    int rows, cols;
    public bool Exist1(char[][] board, string word) {
        rows = board.Length;
        cols = board[0].Length;  
        
        #region Check the occurence of first letter vs last letter based to reduce the traversing tim.
        int first = 0, last = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < cols; column++)
            {
                if (board[row][column] == word[0])
                {
                    first++;
                }
                else if (board[row][column] == word[word.Length - 1])
                {
                    last++;
                }
            }
        }
        if (last < first)
        {
            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            word = new string(chars);
        }
        #endregion
        
        for (int I = 0; I < rows; I++)
        {
            for (int II = 0; II < cols; II++)
            {
                bool[,] isvisted = new bool[rows,cols];
                if(DFS(board, word, I, II, 0, ref isvisted))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool DFS(char[][] board, string word, int I, int II, int index, ref bool[,] isvisited)
    {
        //if match found,procceed with its neighbour     
        if(board[I][II]==word[index] && !isvisited[I,II])
        {
            if(index+1==word.Length) return true;
            
            isvisited[I,II] = true;
            int[][] directions = new int[][]
            {        
                new int[] {0, -1}, //left
                new int[] {1, 0}, //down               
                new int[] {0, 1}, //right
                new int[] {-1, 0} //up
            };
            bool ans=false;
            for(int k=0;k<4;k++)
            {
                int X = I + directions[k][0];
                int Y = II + directions[k][1];
                if(!(X >= rows || X < 0 || Y < 0 ||Y >= cols))
                {
                    //OR, for if ans is found in any of the directions
                    ans |= DFS(board, word, X, Y, index+1, ref isvisited);
                    if(ans) return ans;
                }
            }
            isvisited[I,II] = false;
        }
        return false;
    }

}