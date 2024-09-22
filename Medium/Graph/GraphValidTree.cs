public class GraphValidTree
{
    //VVIMP
    //Note: Graph can be tree if there are no cycles detected. 
    //Can be solved by BFS/DFS using a visited array. to check for cycles
    //OR with Union Find / Disjoint set
    //Example of Union find.
    
    public bool ValidTree(int n, int[][] edges) 
    {
        if(edges.Length != n - 1) return false;

        UnionFind union = new UnionFind(n);

        foreach (int[] item in edges)
        {
            if(!union.Union(item[0], item[1]))
            {
                return false; //cycle detected.
            }
        }

        return true;
    }

    public class UnionFind
    {
        public int[] parent;
        public int[] rank;

        public UnionFind(int size)
        {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        // Find Operation: Determines which subset a particular element is in. This can be used to detect cycles.
        public int Find(int node)
        {
            if(parent[node] != node)  //if what was initialized is not true, then find its parent.
            {
                parent[node] = Find(parent[node]); //Path compression
            }
            return parent[node];
        }

        public bool Union(int node1, int node2)
        {
            int root1 = Find(node1);
            int root2 = Find(node2);

            if(root1 == root2) return false; //Cycle detected

            //Union by rank
            if(rank[root1] > rank[root2])
            {
                parent[root2] = root1;
            }
            else if(rank[root2] > rank[root1])
            {
                parent[root1] = root2;
            }
            else 
            {
                parent[root2] = root1;
                rank[root1]++;
            }
            return true;
        }
    }

// Revise
// Union-Find Data Structure: This structure helps keep track of elements that are split into one or more disjoint sets.
// Union Operation: Connects two elements.

    //DFS Approach
    public bool ValidTreeFS(int n, int[][] edges)
    {
        if(edges.Length != n - 1) return false;

        #region create graph
        var graph = new Dictionary<int, List<int>>();
        //Create a adjacency List
        for (int I = 0; I < n; I++)
        {
            graph[I] = new List<int>();
        }

        foreach (int[] edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }
        #endregion

        var visited = new HashSet<int>();
        if(!DFS(graph, visited, 0, -1)) return false;

        return true;
    }

    public bool DFS(Dictionary<int, List<int>> graph, HashSet<int> nodes, int node, int parent)
    {
        if(nodes.Contains(node)) return false;
        nodes.Add(node);

        foreach (var neighbor in graph[node])
        {
            if(neighbor == parent) continue;
            if(!DFS(graph, nodes, neighbor, node)) return false;
        }
        return true;
    }

}