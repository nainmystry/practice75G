public class PowXN
{
    //Exponentiation by Squaring
    //For even power(n) of x, x = x * x & n = n / 2;
    //For odd  power(n) of x, x = ans * x & n = n - 1;
    //With the above approach the time complexity will be (log n)

    public double MyPow1(double x, int n) {
        double ans = 1.0;
        long nn = n;
        if(n < 0) nn = nn * -1;
        while(nn > 0)
        {
            if(nn % 2 == 1)
            {
                ans = ans * x;
                nn = nn -1;
            }
            else{
                x = x * x;
                nn = nn / 2;
            }
        }
        if(n < 0) ans = (double)(1.0 / ans);
        return ans;
    }

    //Optimized solution
    public double MyPow(double x, int n) 
    {
       if( n < 0)
        {
            n =-n;
            x=1/x;
        }
        double pow =1;

        while(n!=0)
        {
            if((n&1) != 0 ) // n%2
            {
                pow*=x;
            }

            x*=x; //
            n>>>=1 ; //( n/=1 or n = n/2)
        }
        return pow;
    }
}