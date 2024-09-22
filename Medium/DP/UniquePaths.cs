using System.Globalization;

public class UniquePath
{
    //2D array dolution
    public int UniquePaths(int m, int n) {
        if(m == 0 || n == 0) return 0;

        int[,] dp = new int[m,n];
        
        for (int i = 0; i < m; i++) dp[i, 0] = 1; //get first row
        for (int j = 0; j < n; j++) dp[0, j] = 1; //get first column

        for (int I = 1; I < m; I++)
        {
            for (int II = 1; II < n; II++)
            {
                dp[I,II] = dp[I - 1, II] + dp[I, II - 1]; // Sum of the paths from the cell above & left
            }
        }

        return dp[m - 1, n - 1];
    }


    //1D Array solution
        public int UniquePaths1D(int m, int n) {
            if(m == 0 || n == 0) return 0;

            int[] dp = new int[n];
            Array.Fill(dp, 1);
            for (int I = 1; I < m; I++)
            {
                for (int II = 1; II < n; II++)
                {
                    dp[II] = dp[II] + dp[II-1];
                }
            }

            return dp[n - 1];
        }

    //Recursion
    public int UniquePathsRecursion(int m, int n){
        // m - vertical
        // n - horizontal
        
        // G(1, 1) = 0
        // G(k, 1) = 1
        // G(1, k) = 1
        // G(n, m) = G(n-1, m) + G(n, m-1)
     
        
        // Recursion
        if (m == 1 && n == 1)
            return 0;
        
        if (m == 1)
            return 1;
        
        if (n == 1)
            return 1;
        
        return UniquePathsRecursion(m-1, n) + UniquePathsRecursion(m, n-1);
    }
}