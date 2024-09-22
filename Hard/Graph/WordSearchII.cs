public class WordSearchII
{
    int rows, cols;
    int[][] directions = new int[][]
            {        
                new int[] {0, -1}, //left
                new int[] {1, 0}, //down               
                new int[] {0, 1}, //right
                new int[] {-1, 0} //up
            };
    public IList<string> FindWords(char[][] board, string[] words) {
        rows = board.Length;
        cols = board[0].Length;
        HashSet<char> chars = new HashSet<char>();
        var res = new List<string>();
        for (int I = 0; I < rows; I++)
        {
            for (int II = 0; II < cols; II++)
            {
                chars.Add(board[I][II]);            
            }
        }

        foreach (string str in words)
        {
            var charArr = str.ToCharArray();
            int firstV = 0, lastV = 0;
            bool breakloop = false;
            foreach (char c in charArr)
            {
                if(c == str[0])
                firstV++;
                else if(c == str[str.Length - 1])
                lastV++;
                if(!chars.Contains(c))
                {
                    breakloop = true;
                    break;
                }
            }
            if(breakloop)
            continue;
            var updatedStr = str;  
            if(lastV < firstV)
            {          
                Array.Reverse(charArr);
                updatedStr = new string(charArr);
            }
            bool wordFound = false;
            for (int I = 0; I < rows; I++)
            {
                for (int II = 0; II < cols; II++)
                {
                    bool[,] isvisited = new bool[rows,cols];
                    if(DFS(board, updatedStr, I, II, 0, ref isvisited))
                    {
                        wordFound = true;
                        break;
                    }
                }
            }
            if(wordFound)
            res.Add(str);
        }

        return res;
    }

    private bool DFS(char[][] board, string updatedStr,int I,int II, int index, ref bool[,] isvisited)
    {
        if(updatedStr[index] == board[I][II] && !isvisited[I,II])
        {
            if(index + 1 == updatedStr.Length) return true;

            isvisited[I,II] = true;
            bool ans = false;

            for (int K = 0; K < 4; K++)
            {
                int X = I + directions[K][0];
                int Y = II + directions[K][1];

                if(!(X >= rows || X < 0 || Y < 0 ||Y >= cols))
                {
                    //OR, for if ans is found in any of the directions
                    ans |= DFS(board, updatedStr, X, Y, index+1, ref isvisited);
                    if(ans) return ans;
                }
            }
            isvisited[I,II] = false;
        }
        return false;
    }
}