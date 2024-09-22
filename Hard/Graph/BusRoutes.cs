using System.Runtime.InteropServices;

public class BusRoutes
{
    public int NumBusesToDestination(int[][] routes, int source, int target) {
        if(source == target) return 0;

        Dictionary<int, List<int>> stopRoutes = new Dictionary<int, List<int>>();

        for (int I = 0; I < routes.Length; I++)
        {
            foreach (int stop in routes[I])
            {
                if (!stopRoutes.ContainsKey(stop)) {
                    stopRoutes[stop] = new List<int>();
                }
                stopRoutes[stop].Add(I);
            }
        }

        Queue<int> queue = new Queue<int>();
        HashSet<int> visitedStops = new HashSet<int>();
        HashSet<int> visitedRoutes = new HashSet<int>();
        queue.Enqueue(source);
        visitedStops.Add(source);
        int buses = 0;
        while(queue.Count > 0)
        {
            int stopsAtCurrentLevel = queue.Count;
            for (int I = 0; I < stopsAtCurrentLevel; I++)
            {
                int currStop = queue.Dequeue();
                List<int> busesAtStop = stopRoutes.ContainsKey(currStop) ? stopRoutes[currStop] : new List<int>();

                foreach (int bus in busesAtStop)
                {
                    if(visitedRoutes.Contains(bus)) continue;

                    visitedRoutes.Add(bus);
                    foreach (int nextStop in routes[bus])
                    {
                        if(visitedStops.Contains(nextStop)) continue;

                        visitedStops.Add(nextStop);

                        if(nextStop == target) return buses + 1;

                        queue.Enqueue(nextStop);
                    }
                }
            }
            buses++;
        }

        return -1;
    }
}