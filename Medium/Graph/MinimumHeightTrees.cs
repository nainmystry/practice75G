public class MinimumHeightTrees
{

    //Removing leaf nodes approach
    public IList<int> FindMinHeightTrees1(int n, int[][] edges) {
        if (n == 1) {
            return new List<int> { 0 }; 
        }

        Dictionary <int, List<int>> graph = new Dictionary<int, List<int>>();
        foreach (int[] edge in edges)
        {
            if(!graph.ContainsKey(edge[0]))
            {
                graph[edge[0]] = new List<int>();
            }
            if(!graph.ContainsKey(edge[1]))
            {
                graph[edge[1]] = new List<int>();
            }
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        HashSet<int> leaves = new HashSet<int>();
        foreach (var kvp in graph)
        {
            if(kvp.Value.Count == 1)
            leaves.Add(kvp.Key);
        }

        while(n > 2)
        {
            n -= leaves.Count;
            HashSet<int> newLeaves = new HashSet<int>();
            foreach (int leaf in leaves)
            {
                int neighbor = graph[leaf][0];
                graph[neighbor].Remove(leaf);
                if(graph[neighbor].Count == 1)
                newLeaves.Add(neighbor);                
            }
            leaves = newLeaves;
        }

        return leaves.ToList();
    }

    //Using BFS + leaf nodes approach
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        List<int> answer = new ();
        Dictionary<int, HashSet<int>> graph = new ();
        Queue<int> queue = new ();

        for(int i = 0; i < n; i ++)
        {
            graph.Add(i, new ());
        }

        foreach(var edge in edges)
        {
            var from = edge[0];
            var to = edge[1];

            graph[from].Add(to);
            graph[to].Add(from);
        }

        // Add first set of leaves
        for(int i = 0; i < n; i++)
        {
            // leaves have only one neighbour
            if(graph[i].Count == 1)
            {
                queue.Enqueue(i);
            }
        }        

        while(graph.Count > 2)
        {
            int nodes = queue.Count;

            while(nodes > 0)
            {
                int node = queue.Dequeue();
                // Leaf has only one neighbour
                int neighbour = graph[node].First();
                // remove the leaf
                graph.Remove(node);
                // remove node edge from neighbour
                graph[neighbour].Remove(node);

                // if neighbour becomes leaf add it to the queue
                if(graph[neighbour].Count == 1)
                {
                    queue.Enqueue(neighbour);
                }

                nodes --;
            }
        }

        // remaining nodes in the graph are centeroids
        foreach(var pair in graph)
        {
            answer.Add(pair.Key);
        }

        return answer.ToArray();
    }
}