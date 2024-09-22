public class ValidSudoku
{
    /*
    Scope of Learning
    - Validation of constraints in a grid or matrix.        
    - Understanding nested loops and indexing in a 2D array.
    */
    public bool IsValidSudoku(char[][] board) {
        
        // Create arrays of hash sets for rows, columns, and sub-boxes
        HashSet<char>[] rows = new HashSet<char>[9];
        HashSet<char>[] columns = new HashSet<char>[9];
        HashSet<char>[] boxes = new HashSet<char>[9];

        for (int I = 0; I < 9; I++)
        {            
            rows[I] = new HashSet<char>();
            columns[I] = new HashSet<char>();
            boxes[I] = new HashSet<char>();
        }

        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                char num = board[c][r];
                if(num == '.')
                continue;

                //checks at row level
                if(rows[r].Contains(num))
                return false;

                rows[r].Add(num);

                //check if num exists in column
                if(columns[c].Contains(num))
                return false;

                columns[c].Add(num);

                //check within box. Rows and cols start from 0 to 8. Max box Index will be 9.
                int boxIndex = (r / 3) * 3 + (c / 3);
                if(boxes[boxIndex].Contains(num))
                return false;

                boxes[boxIndex].Add(num);
            }   
        }

        return true;
    }
}