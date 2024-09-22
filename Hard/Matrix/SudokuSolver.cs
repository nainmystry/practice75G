public class SudokuSolver
{
    public void SolveSudoku(char[][] board) {
        Solve(board);
    }

    public bool Solve(char[][] board)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if(board[i][j] == '.')
                {
                    for (char c = '1'; c <= '9'; c++)
                    {
                        if(IsValid(board,i,j,c))
                        {
                             board[i][j] = c;

                            if (Solve(board))
                            {
                                return true;
                            }
                            else
                            {
                                board[i][j] = '.'; // Backtrack
                            }
                        }
                    }
                    return false;

                }
            }
        }
        return true;
    }

    private bool IsValid(char[][] board, int row, int col, char c)
    {
        for (int i = 0; i < 9; i++)
        {
            // Check row
            if (board[row][i] == c) return false;

            // Check column
            if (board[i][col] == c) return false;

            // Check 3x3 sub-box
            if (board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] == c) return false;
        }
        return true;
    }
}



//Optimized Approach with Bit Mask
public class SudokuSolver2
{
    private int[] rows = new int[9];
    private int[] cols = new int[9];
    private int[] boxes = new int[9];

    public void SolveSudoku(char[][] board)
    {
        // Initialize the bitmasks for rows, cols, and boxes
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] != '.')
                {
                    int digit = board[i][j] - '1';
                    int boxIndex = (i / 3) * 3 + j / 3;
                    rows[i] |= 1 << digit;
                    cols[j] |= 1 << digit;
                    boxes[boxIndex] |= 1 << digit;
                }
            }
        }

        Solve(board, 0, 0);
    }

    private bool Solve(char[][] board, int row, int col)
    {
        if (row == 9) return true; // If all rows are done
        if (col == 9) return Solve(board, row + 1, 0); // Move to next row
        if (board[row][col] != '.') return Solve(board, row, col + 1); // Skip filled cells

        int boxIndex = (row / 3) * 3 + col / 3;
        for (int digit = 0; digit < 9; digit++)
        {
            int mask = 1 << digit;
            if ((rows[row] & mask) == 0 && (cols[col] & mask) == 0 && (boxes[boxIndex] & mask) == 0)
            {
                // Place the digit
                board[row][col] = (char)('1' + digit);
                rows[row] |= mask;
                cols[col] |= mask;
                boxes[boxIndex] |= mask;

                // Recur for next cell
                if (Solve(board, row, col + 1)) return true;

                // Backtrack
                board[row][col] = '.';
                rows[row] &= ~mask;
                cols[col] &= ~mask;
                boxes[boxIndex] &= ~mask;
            }
        }

        return false; // Trigger backtracking
    }
    }