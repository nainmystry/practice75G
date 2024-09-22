using System.Text;

public class ProductExceptSelf
{
    //Approach 1 using Refix & Suffix array
    public int[] ProductExceptSelf1(int[] nums) {
        int n = nums.Length;
        int[] prefix = new int[n];
        int[] suffix = new int[n];

        prefix[0] = 1;
        for (int I = 1; I < n; I++)
        {
         prefix[I] = prefix[I-1] * nums[I - 1];   
        }

        suffix[n - 1] = 1;
        for (int I = n - 2; I >= 0; I--)
        {
         suffix[I] = suffix[I+1] * nums[I + 1];   
        }
        int[] ans = new int[n];
        for (int I = 0; I < n; I++)
        {
            ans[I] = prefix[I] * suffix[I];
        }
        return ans;
    }

    //Space optimized approach storing the prefix & suffix values in single array
    public int[] ProductExceptSelf2(int[] nums){
        int n = nums.Length;
        int[] res = new int[n];
        res[0] = 1;
        res[n - 1] = 1;
        int l = 1;
        int r = n - 1;
        while(l < n){
            res[l] = res[l - 1] * nums[l - 1];
            l++;
        }
        int rightProduct = 1;
        while(r >= 0){
            res[r] *= rightProduct;
            rightProduct *= nums[r];
            r--;
        }
        return res;
    }

    public string ClearDigits(string s) {
        try
        {
            if(s.Length == 1 )
                return s;
            
            StringBuilder sb = new StringBuilder();
            
            foreach(char cs in s){
                if(Char.IsDigit(cs)){
                    sb.Length--;
                }
                else{
                    sb.Append(cs);
                }
            }
            return sb.ToString();
        }
        catch(Exception e){
            throw;
        }        
        
    }

     public int FindWinningPlayer(int[] skills, int k) {
     try
     {
        int prev = skills[0], winInd = 0, conWin = 0, n = skills.Length;
        for (int I = 1; I < n; I++)
        {
            if(skills[I] > prev){
                prev = skills[I];
                conWin = 0;
                winInd = I;
            }
            conWin++;
            if(conWin == k) break;
        }        
        return winInd;
     }
     catch (Exception ex)
     {
        throw;
     }   
    }
}