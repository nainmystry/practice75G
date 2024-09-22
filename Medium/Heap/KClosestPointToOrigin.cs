using System.Security.Cryptography.X509Certificates;

public class KClosestPointToOrigin
{

    /*
    Brute Force Approach.
    - Get the Dist of all the points iteratively.
    - Store it in KeyValue Pair
    - Sort the keyvalue pair, take the k items.
    */
    public int[][] KClosestBF(int[][] points, int k) {
     Dictionary<double,List<int[]>> kClosestPoints = new Dictionary<double, List<int[]>>();

     if(points.Length == 1 && k == 1){
        return points;
     }
     int N = points.Length;
     int x1 = 0, y1 = 0;
     int x2 =0, y2 = 0;
     for (int I = 0; I < N; I++)
     {
        x2 = points[I][0];y2 = points[I][1];
        var currentDist = Math.Sqrt(Math.Pow((x1 - x2),2) + Math.Pow((y1 - y2),2));        
        
        if(kClosestPoints.ContainsKey(currentDist)){
            kClosestPoints[currentDist].Add(points[I]);
        }
        else{
            kClosestPoints[currentDist] = new List<int[]>(){points[I]};
        }
        
     }

    var closestPoints = kClosestPoints.OrderBy(x => x.Key).Take(k).Select(x => x.Value).ToList();
    List<int[]> result = new ();
    foreach (var item in closestPoints)
    {
        if(result.Count < k){
            result.AddRange(item);
        }
        else{
            break;
        }
    }
return result.ToArray();
    }

/*
Used PriorityQueue Data Structure. 
- It stores the data based on priority, Min to Max or Max to Min

*/
    public int[][] KClosest(int[][] points, int k) {
        PriorityQueue<int[],int> queue  = new PriorityQueue<int[],int>();
        var result = new int[k][];
        foreach(var point in points){
            var x = point[0];
            var y = point[1];
            queue.Enqueue(new int[2]{x,y},((x*x) + (y*y)));
        } 
        for(int i=0;i<k;i++){
            result[i] = queue.Dequeue();
        }
        var res = result;
        return res;
    }
}