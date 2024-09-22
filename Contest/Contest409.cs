using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

public class Contest409
{
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries) {
        // Initialize the graph
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
            if (i < n - 1)
                graph[i].Add(i + 1);
        }

        // To store the results
        int[] answer = new int[queries.Length];

        // Process each query
        for (int i = 0; i < queries.Length; i++)
        {
            int u = queries[i][0];
            int v = queries[i][1];
            graph[u].Add(v);

            // Compute shortest path from 0 to n-1 using Dijkstra's algorithm
            answer[i] = Dijkstra(graph, n);
        }

        return answer;
    }

    private int Dijkstra(List<int>[] graph, int n)
    {
        int[] dist = new int[n];
        Array.Fill(dist, int.MaxValue);
        dist[0] = 0;
          
        PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
        pq.Enqueue((0, 0), 0); // (distance, node)

        while (pq.Count > 0)
        {
            var (currentDist, u) = pq.Dequeue();

            foreach (var v in graph[u])
            {
                int newDist = currentDist + 1;
                if (newDist < dist[v])
                {
                    if (u != n - 1){
                        pq.Enqueue((newDist, v), v);
                        dist[v] = newDist;
                    }                   
                }
            }
        }
        var ans = dist[n - 1];
        return ans;
    }
}
    public class neighborSum {
    
    private Dictionary<int, int[]> gridMap;
    private int[][] directions = new int[][]{
        new int[] {-1, 0},
        new int[] {0, -1},
        new int[] {1, 0},
        new int[] {0, 1}
    } ;
    private int[][] diagnoalDirections = new int[][]{
        new int[] {-1, -1},
        new int[] {-1, 1},
        new int[] {1, -1},
        new int[] {1, 1}
    } ;
    private int rows = 0;
    private int cols = 0;
    int[][] newGrid;
    public neighborSum(int[][] grid) {
        rows = grid.Length;
        cols = grid[0].Length;
        newGrid = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            newGrid[i] = new int[cols];
        }
        gridMap = new Dictionary<int, int[]>();
        for (int i = 0; i < grid.Length; i++)
        {
            for (int ii = 0; ii < grid[0].Length; ii++)
            {
                gridMap[grid[i][ii]] = new int[] {i, ii};
                newGrid[i][ii] = grid[i][ii];
            }
        }
    }
    
    public int AdjacentSum(int value) {
        if(gridMap.TryGetValue(value, out var extractArray))
        {
            int sum = 0;
            int centerX = extractArray[0], centerY = extractArray[1];
            foreach (int[] dir in directions)
            {
                int x = centerX + dir[0];
                int y = centerY + dir[1];
                if(x < 0 || x >= rows || y < 0 || y >= cols)
                continue;
                else
                sum += newGrid[x][y];
            }
            return sum;
        }
        else{
            return 0;
        }
    }
    
    public int DiagonalSum(int value) {
        if(gridMap.TryGetValue(value, out var extractArray))
        {
            int sum = 0;
            int centerX = extractArray[0], centerY = extractArray[1];
            foreach (int[] dir in diagnoalDirections)
            {
                int x = centerX + dir[0];
                int y = centerY + dir[1];
                if(x < 0 || x >= rows || y < 0 || y >= cols)
                continue;
                else
                sum += newGrid[x][y];
            }
            return sum;
        }
        else{
            return 0;
        }
    }
}
