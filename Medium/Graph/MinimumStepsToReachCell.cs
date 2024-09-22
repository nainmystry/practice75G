public class MinimumStepsToReachCell
{
    // C# program to find minimum steps to reach to
    // specific cell in minimum moves by Knight


    // Class for storing a cell's data
    public class Cell {
        public int x, y;
        public int dis;

        public Cell(int x, int y, int dis)
        {
            this.x = x;
            this.y = y;
            this.dis = dis;
        }
    }

    // Utility method returns true
    // if (x, y) lies inside Board
    static bool isInside(int x, int y, int N)
    {
        if (x >= 1 && x <= N && y >= 1 && y <= N)
            return true;
        return false;
    }

    // Method returns minimum step
    // to reach target position
    static int minStepToReachTarget(int[] knightPos,
                                    int[] targetPos, int N)
    {
        // x and y direction, where a knight can move
        int[] dx = { -2, -1, 1, 2, -2, -1, 1, 2 };
        int[] dy = { -1, -2, -2, -1, 1, 2, 2, 1 };

        // queue for storing states of knight in board
        Queue<Cell> q = new Queue<Cell>();

        // push starting position of knight with 0 distance
        q.Enqueue(new Cell(knightPos[0], knightPos[1], 0));

        Cell t;
        int x, y;
        bool[, ] visit = new bool[N + 1, N + 1];

        // make all cell unvisited
        for (int i = 1; i <= N; i++)
            for (int j = 1; j <= N; j++)
                visit[i, j] = false;

        // visit starting state
        visit[knightPos[0], knightPos[1]] = true;

        // loop until we have one element in queue
        while (q.Count != 0) {
            t = q.Peek();
            q.Dequeue();

            // if current cell is equal to target cell,
            // return its distance
            if (t.x == targetPos[0] && t.y == targetPos[1])
                return t.dis;

            // loop for all reachable states
            for (int i = 0; i < 8; i++) {
                x = t.x + dx[i];
                y = t.y + dy[i];

                // If reachable state is not yet visited and
                // inside board, push that state into queue
                if (isInside(x, y, N) && !visit[x, y]) {
                    visit[x, y] = true;
                    q.Enqueue(new Cell(x, y, t.dis + 1));
                }
            }
        }
        return int.MaxValue;
    }   
}