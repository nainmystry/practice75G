using System.Text;

public class AlienDictionary
{
    //Topological sort (Kahn's algo)
    public string AlienOrder(string[] words)
    {
        // Step 1: Initialize the graph and in-degree dictionary
        var graph = new Dictionary<char, HashSet<char>>();
        var inDegree = new Dictionary<char, int>();

        // Initialize the graph with all unique characters in the input words
        foreach (var word in words)
        {
            foreach (var c in word)
            {
                if (!graph.ContainsKey(c))
                {
                    graph[c] = new HashSet<char>();
                    inDegree[c] = 0;
                }
            }
        }

        // Step 2: Build the graph by comparing adjacent words
        for (int i = 0; i < words.Length - 1; i++)
        {
            string word1 = words[i];
            string word2 = words[i + 1];

            // Check if word2 is a prefix of word1 (invalid case)
            if (word1.Length > word2.Length && word1.StartsWith(word2))
            {
                return ""; // invalid order
            }

            // Find the first difference between word1 and word2
            for (int j = 0; j < Math.Min(word1.Length, word2.Length); j++)
            {
                if (word1[j] != word2[j])
                {
                    // Create an edge from word1[j] -> word2[j]
                    if (!graph[word1[j]].Contains(word2[j]))
                    {
                        graph[word1[j]].Add(word2[j]);
                        inDegree[word2[j]]++;
                    }
                    break; // Stop at the first difference
                }
            }
        }

        // Step 3: Perform topological sort using Kahn's Algorithm (BFS)
        var queue = new Queue<char>();
        var result = new StringBuilder();

        // Start with characters that have 0 in-degree (no dependencies)
        foreach (var key in inDegree.Keys)
        {
            if (inDegree[key] == 0)
            {
                queue.Enqueue(key);
            }
        }

        // Process the graph
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            result.Append(current);

            // For each neighbor, reduce its in-degree by 1
            foreach (var neighbor in graph[current])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        // Step 4: Check if topological sort includes all characters
        if (result.Length != graph.Count)
        {
            return ""; // If not, there is a cycle (invalid order)
        }

        return result.ToString();
    }
}