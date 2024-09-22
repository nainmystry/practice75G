public class CheapestFlight
{
    //VVIMP
    //Revise
    //Bellman Ford Approach to find the Shortest Path in weighted Graphs.
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue);
        prices[src] = 0;

        for (int i = 0; i <= k; i++)
        {
            int[] tempPrice = (int[])prices.Clone();
            foreach (int[] flight in flights)
            {
                int uSource = flight[0], vDestination = flight[1], price = flight[2];
                if(prices[uSource] == int.MaxValue) continue;
                if(prices[uSource] + price < tempPrice[vDestination])
                {
                    tempPrice[vDestination] = prices[uSource] + price;
                }
            }
            prices = tempPrice;
        } 
        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }
}