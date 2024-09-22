public class CourseScheduleII
{
    //Revise

    //Topological Sorting.

    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        List<List<int>> graph = new List<List<int>>();
        int[] degrees = new int[numCourses]; //represents course

        for (int I = 0; I < numCourses; I++)
        {
            graph.Add(new List<int>());
        }

        foreach (int[] prerequisite in prerequisites)
        {
            int courseA = prerequisite[0];
            int courseB = prerequisite[1];
            graph[courseB].Add(courseA);
            degrees[courseA]++;
        }


        Queue<int> queue = new Queue<int>();
        List<int> res = new List<int>();

        for (int I = 0; I < numCourses; I++)
        {
            if(degrees[I] == 0)
            {
                queue.Enqueue(I);
            }
        }

        while(queue.Count > 0)
        {
            int course = queue.Dequeue();
            res.Add(course);

            foreach (var neighbor in graph[course])
            {
                degrees[neighbor]--;
                if(degrees[neighbor] == 0)
                queue.Enqueue(neighbor);
            }
        }

        if(res.Count == numCourses)
        {
            return res.ToArray();
        }
        else{
            return new int [0];
        }
    }
}