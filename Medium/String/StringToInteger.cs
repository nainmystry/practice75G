using System.Data.SqlTypes;
using System.Text;

public class StringToInteger
{
    //Failed Approach 
    public int Atoi1(string s)
    {
        s = s.Trim();
        StringBuilder sb = new StringBuilder();
        bool start = true, firstZero = true;
        foreach (char c in s)
        {
            if(start && c == '-')
            {
                sb.Append('-');
            }
            else if(char.IsNumber(c))
            {
                if(firstZero && c == '0')
                {
                    start = false;
                    continue;
                }
                firstZero = false;
                sb.Append(c);
            }
            else{
                break;
            }
            start = false;
        }
        if(sb.Length == 0)
        {
            sb.Append("0");
        }
        long maxVal = long.Parse(sb.ToString());
        if(maxVal > int.MaxValue)
        {
            return int.MaxValue;
        }
        else{
            return (int)maxVal;
        }
    }

    public int Atoi(string s)
    {
        s= s.Trim(); 
        if(s.Length == 0) return 0;
        int sign = 1, n = s.Length, i = 1;
        if ((s[0] == '-' || s[0] == '+')) {
            sign = (s[0] == '-') ? -1 : 1;
        }

        long result = 0;
        while (i < n && Char.IsDigit(s[i])) {
            result = result * 10 + (s[i] - '0');
            if (result * sign >= int.MaxValue) return int.MaxValue;
            if (result * sign <= int.MinValue) return int.MinValue;
            i++;
        }

        return (int)(result * sign);
    }
}