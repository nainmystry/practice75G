using System.Net.Mail;

public class MinimumKnightMoves
{
      public int MinKnightMoves(int x, int y) 
      {

        int[][] dirs = new int[][]{
            new int[]{2,1},
            new int[]{1,2},
            new int[]{-1,2},
            new int[]{-2,1},
            new int[]{-2,-1},
            new int[]{-1,-2},
            new int[]{1,-2},
            new int[]{2,-1},
        };
        x = Math.Abs(x);
        y = Math.Abs(y);

        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[]{0,0});

        HashSet<string> visited = new HashSet<string>();
        visited.Add("0,0");
        
        int moves = 0;
        while(queue.Count> 0)
        {
            int size = queue.Count;

            for (int I = 0; I < size; I++)
            {
                int[] curr = queue.Dequeue();
                int currX = curr[0];
                int currY = curr[1];

                if(currX == x && currY == y)
                {
                    return moves;
                }

                foreach (var direction in dirs) 
                {
                    int newX = currX + direction[0];
                    int newY = currY + direction[1];
                    
                    // Convert coordinates to string for HashSet
                    string newPos = newX + "," + newY;

                    if(!visited.Contains(newPos) && newX >= -2 && newY >= -2)
                    {
                        visited.Add(newPos);
                        queue.Enqueue(new int[] {newX, newY});
                    }
                }
            }
            moves++;
        }
        return -1;
    } 
}