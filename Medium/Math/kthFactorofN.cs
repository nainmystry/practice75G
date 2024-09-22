public class FactorOfN {
    public int KthFactor(int n, int k) {
        List<int> factorArray = new List<int>();
            // Factorials are always less than or equal to n / 2 and itselft
            int mid = n / 2 + 1;
            for(int x = 1; x < mid; x++)
            {
                if(n % x == 0) factorArray.Add(x);
            }
            // Factor will also include itself
            factorArray.Add(n);

            // If there are not enough factors to satisfy k, return -1
            if(factorArray.Count < k) return -1;

            return factorArray[k - 1];
    }
}