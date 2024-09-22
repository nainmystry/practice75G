public class CountingBits
{

    //Solution 1
    public int[] CountBits1(int n) {
        List<int> ints = new List<int>();
        ints.Add(0);
        if(n == 0)
        return ints.ToArray();

        if(n == 1)
        {
            ints.Add(1);
            return ints.ToArray();
        }    

        for (int i = 1; i <= n; i++)
        {
            var str = Convert.ToString(i,2).ToCharArray();
            var cnt = str.Where(x => x == '1').Count();
            ints.Add(cnt);
        }

        return ints.ToArray();
    }

    //Solution 2
    public int[] CountBits(int n){
        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            dp[i] = dp[i >> 1] + (i & 1);
        }
        return dp;
    }    
}