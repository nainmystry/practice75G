//Example of directed graph.

public class CourseSchedule
{
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        try
        {
            List<List<int>> adj = new List<List<int>>();
            for (int I = 0; I < numCourses; I++)
                adj.Add(new List<int>());

            foreach (int[] item in prerequisites)
                adj[item[0]].Add(item[1]);
            
            int[] degree = new int[numCourses];
            for (int I = 0; I < numCourses; I++)
            {
                foreach (int it in adj[I])
                    degree[it]++;
            }

            Queue<int> ints = new Queue<int>();
            for (int I = 0; I < numCourses; I++)
            {
                if(degree[I] == 0){
                    ints.Enqueue(I);
                }
            }

            List<int> topo = new List<int>();
            // o(v + e)
            while (ints.Count > 0) {
                int node = ints.Dequeue();
                topo.Add(node);
                // node is in your topo sort
                // so please remove it from the indegree

                foreach (int item in adj[node])
                {
                    degree[item]--;
                    if(degree[item]==0) ints.Enqueue(item);
                }
            }

            if (topo.Count == numCourses) return true;
            return false;
        }
        catch (System.Exception ex)
        {
            
            throw;
        }   
    }
}