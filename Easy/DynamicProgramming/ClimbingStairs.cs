using System.Security.Cryptography;

public class ClimbingStairs {

    //Time consuming
    public int ClimbStairs1(int n) {
        if(n == 0) return 1;
        if(n == 1) return 1;
                    
        return ClimbStairs1(n - 1) + ClimbStairs1(n - 2);
    }

    //Adding previous steps to N; iterating over previously added step.
    public int ClimbStairs(int n) {
        if(n == 1) return 1;
        int prev = 1;
        int curr = 1;
        for(int i=1; i<n; i++){
            int temp = curr; // current value
            curr += prev; // adding previus steps value to current
            prev = temp; // updating previus value with new current value.
        }
        return curr;
    }

}