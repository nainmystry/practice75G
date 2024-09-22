public class ConnectedCompinUDGraph
{
    //Number of Connected Components in Undirected graph
    //Revise 
    //VVIMP
    private int[] p;
    public int countComponents(int n, int[][] edges) {
        p = new int[n];
        for (int I = 0; I < n; I++)
        {
            p[I] = I;
        }

        foreach (int[] edge in edges)
        {
            int a = edge[0], b = edge[1];
            p[find(a)] = find(b);
        }

        int ans = 0;
        for (int I = 0; I < n; I++)
        {
            if(I == find(I))
            {
                ++ans;
            }
        }
        return ans;
    }

    private int find(int x) {
        if (p[x] != x) {
            p[x] = find(p[x]);
        }
        return p[x];
    }
}