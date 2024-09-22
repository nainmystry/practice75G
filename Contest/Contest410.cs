using System.Security.Cryptography;

public class Contest410
{
    public int FinalPositionOfSnake(int n, IList<string> commands) {
        int[][] grid = new int[n][];
        int vals = 0;
        for (int I = 0; I < n; I++)
        {
            grid[I] = new int[n];
            for (int II = 0; II < n; II++)
            {
                grid[I][II] = vals;
                vals++;
            }
        }

        int[] index = new int[] {0,0};
        foreach (string str in commands)
        {
            if(str == "UP")
            {
                index[0] = index[0] - 1;
                index[1] = index[1];
            }
            else if (str == "RIGHT")
            {
                index[0] = index[0];
                index[1] = index[1] + 1;
            }
            else if (str == "DOWN")
            {
                index[0] = index[0] + 1;
                index[1] = index[1];
            }
            else
            {
                index[0] = index[0];
                index[1] = index[1] - 1;
            }
        }

        var res = grid[index[0]][index[1]];
    return res;
    }

    public int CountGoodNodes1(int[][] edges) {
        Dictionary<int, HashSet<int>> connectedNodes = new Dictionary<int, HashSet<int>>();
        for (int I = 0; I < edges.Length; I++)
        {
            var key = edges[I][0];
            if(!connectedNodes.ContainsKey(key))
            {
                connectedNodes[key] = new HashSet<int>();
            }
            var val = edges[I][1];
            connectedNodes[key].Add(val);
        }

        Queue<int> goodNodes = new Queue<int>();
        return 0;
    }
    int goodNodesCount = 0; 
    Dictionary<int, List<int>> adjList;
    int[] subtreeSize;
    public int CountGoodNodes(int[][] edges)
    {
        int n = edges.Length + 1;
        adjList = new Dictionary<int, List<int>>();
        subtreeSize = new int[n];
        int goodNodesCount = 0;

         for (int i = 0; i < n; i++) {
            adjList[i] = new List<int>();
        }

        //Mapping adjacency list based on mapping
        foreach (var edge in edges) {
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        GetGoodNodes(0,-1);
        return goodNodesCount;
    }

    private int GetGoodNodes(int node, int parent)
    {
        int size = 1;
        HashSet<int> childSubTree = new HashSet<int>();
        
        foreach (var neighbor in adjList[node]) {
            if (neighbor != parent) {  //prevent from accessing parent
                int childSize = GetGoodNodes(neighbor, node);
                childSubTree.Add(childSize);
                size += childSize;  
            }
        }
        subtreeSize[node] = size;

        // If all children's subtree sizes are the same (or there are no children), the node is good
        if (childSubTree.Count <= 1) {
            goodNodesCount++;
        }

        return size;
    }
}