public class PacificAtlanticWater
{
    //DFS
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        int m = heights.Length;
        int n = heights[0].Length;

        var results = new List<IList<int>>();

        bool[,] canReachPacific = new bool[m,n];
        bool[,] canReachAtlantic = new bool[m,n];

        for(int i = 0; i <  m; i++)
        {
            DFS(heights,canReachPacific,m,n,i,0);
            DFS(heights,canReachAtlantic,m,n,i,n-1);
        }

        for(int j = 0; j < n; j++)
        {
            DFS(heights,canReachPacific,m,n,0,j);
            DFS(heights,canReachAtlantic,m,n,m-1,j);
        }


        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if(canReachPacific[i,j] && canReachAtlantic[i,j])
                {
                    results.Add(new List<int>(){i,j});
                }
            }
        }

        return results;

    }
    private void DFS(int[][] ocean, bool[,] canReach, int m, int n, int row, int col)
    {
        if(canReach[row,col]) return;

        canReach[row,col] = true;

        int[] directions = {-1, 0 , 1, 0, -1};

        for(int dir = 0; dir < 4; dir++)
        {
            int newRow = row + directions[dir];
            int newCol = col + directions[dir + 1];

            //if any block is greater than or equal to [ row, col ] water can go from there.
            if(newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && ocean[newRow][newCol] >= ocean[row][col])
            {
                DFS(ocean,canReach,m,n,newRow,newCol);
            }
        }
    }
}


//BFS
public class PacificAtlanticWaters
{
    public class WaterNodeClass
    {
        public int r;
        public int c;

        public WaterNodeClass(int R, int C)
        {
            r = R;
            c = C;
        }

        public override string ToString() {
            return r.ToString() + "-" + c.ToString();
        }
    }
    public IList<IList<int>> PacificAtlantic(int[][] heights) 
    {
        List<List<int>> result = new ();
        for (int i = 0; i < heights.Length; i++) {
            for (int j = 0; j < heights[0].Length; j++) {
                if (check(heights, i, j)) {
                    result.Add(new List<int>() { i, j });
                }
            }
        }
        return result.Cast<IList<int>>().ToList();
    }

    public bool check(int[][] heights, int i, int j) {
        bool pacific = false;
        bool atlantic = false;

        Queue<WaterNodeClass> q = new ();
        q.Enqueue(new WaterNodeClass(i, j));
        Dictionary<string, int> visited = new ();
        while (q.Count > 0) {
            var WaterNodeClass = q.Dequeue();
            string key = WaterNodeClass.ToString();
            if (visited.ContainsKey(key)) {
                continue;
            }
            visited[key] = 1;
            if (WaterNodeClass.r == 0 || WaterNodeClass.c == 0) pacific = true;
            if (WaterNodeClass.r == heights.Length - 1 || WaterNodeClass.c == heights[0].Length - 1) atlantic = true;
            if (WaterNodeClass.r > 0 && heights[WaterNodeClass.r][WaterNodeClass.c] >= heights[WaterNodeClass.r - 1][WaterNodeClass.c]) {
                q.Enqueue(new WaterNodeClass(WaterNodeClass.r - 1, WaterNodeClass.c));
            }
            if (WaterNodeClass.c > 0 && heights[WaterNodeClass.r][WaterNodeClass.c] >= heights[WaterNodeClass.r][WaterNodeClass.c - 1]) {
                q.Enqueue(new WaterNodeClass(WaterNodeClass.r, WaterNodeClass.c - 1));
            }
            if (WaterNodeClass.r < heights.Length - 1 && heights[WaterNodeClass.r][WaterNodeClass.c] >= heights[WaterNodeClass.r + 1][WaterNodeClass.c]) {
                q.Enqueue(new WaterNodeClass(WaterNodeClass.r + 1, WaterNodeClass.c));
            }
            if (WaterNodeClass.c < heights[0].Length - 1 && heights[WaterNodeClass.r][WaterNodeClass.c] >= heights[WaterNodeClass.r][WaterNodeClass.c + 1]) {
                q.Enqueue(new WaterNodeClass(WaterNodeClass.r, WaterNodeClass.c + 1));
            }
        }

        return pacific && atlantic;
    }
}