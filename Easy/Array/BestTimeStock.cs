public class BestTimeStock {
    public int MaxProfit(int[] prices) {
        if(prices.Length == 0 || prices.Length == 1){
            return 0;
        }

        var buyPrice = prices[0];
        int maxSellPrice = 0;
        for (int I = 1; I < prices.Length; I++)
        {
            if(buyPrice > prices[I]){
                buyPrice = prices[I];
            }
            if(prices[I] - buyPrice > maxSellPrice){
                maxSellPrice = prices[I] - buyPrice;
            }
        }
        Console.WriteLine(maxSellPrice);
        return maxSellPrice;

    }
}