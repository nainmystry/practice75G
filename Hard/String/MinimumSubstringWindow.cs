using System.Runtime;
using System.Text;

public class MinimumSubstringWindow
{
    public string MinWindow1(string s, string t) {
        if(s.Length < t.Length) return string.Empty;
        if(s.Length == 1 && t.Length == 1 && s == t) 
        return s;
        if (s.Length == 1 && t.Length == 1 && s != t)
        {
            return string.Empty;
        }
        
        Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
        foreach (char c in t)
        {
            if(!keyValuePairs.ContainsKey(c))
            {
                keyValuePairs[c] = 0;
            }
            keyValuePairs[c]++;
        }

        int left = 0, right = 1;
        int minCntr = int.MaxValue;
        string ostring = string.Empty;
        List<int> indexes = new List<int>();
        int indx = 0;           
        int leftIndex = 0; 
        while(left < s.Length)
        {
            right = left;
            int cntr = -1;
            StringBuilder stringBuilder = new StringBuilder();
            Dictionary<char, int> temp = new Dictionary<char, int>(keyValuePairs);
            while(right < s.Length)
            {
                if(temp.ContainsKey(s[right]) && temp[s[right]] > 0)
                {
                    if(cntr == -1)
                    {
                        cntr = 0;
                    }
                    if(left == 0)
                    {
                        indexes[indx] = right;
                        indx++;
                    }
                    temp[s[right]]--;                    
                }
                if(cntr >= 0){
                    stringBuilder.Append(s[right]);
                    cntr++;
                } 
                if(!temp.Values.Any(x => x > 0))
                {
                    minCntr = Math.Min(minCntr, cntr);
                    if(minCntr == cntr)
                    {
                        ostring = stringBuilder.ToString();
                    }
                    break;
                }
                right++;
            }
            if(left == 0 && temp.Values.Any(x => x > 0))
            return string.Empty;
            leftIndex++;
            if(leftIndex < indexes.Count)
            {
                left = indexes[leftIndex];
            }
            else{
                left++;
                indexes.Clear();
            }
            if(left - s.Length > t.Length)
            break; 
        }
        return ostring;
    }

    public string MinWindow(string s, string t)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
            return "";

        Dictionary<char, int> tFreq = new Dictionary<char, int>();
        Dictionary<char, int> windowFreq = new Dictionary<char, int>();

        foreach (char c in t)
        {
            if (!tFreq.ContainsKey(c))
                tFreq[c] = 0;
            tFreq[c]++;
        }

        int left = 0, right = 0;
        int required = tFreq.Count;
        int formed = 0;
        int minLen = int.MaxValue;
        int minLeft = 0, minRight = 0;
        while (right < s.Length)
        {
            char c = s[right];
            if (!windowFreq.ContainsKey(c))
                windowFreq[c] = 0;
            windowFreq[c]++;

            if (tFreq.ContainsKey(c) && windowFreq[c] == tFreq[c])
                formed++;

            while (left <= right && formed == required)
            {
                c = s[left];

                if (right - left + 1 < minLen)
                {
                    minLen = right - left + 1;
                    minLeft = left;
                    minRight = right;
                }

                windowFreq[c]--;
                if (tFreq.ContainsKey(c) && windowFreq[c] < tFreq[c])
                    formed--;

                left++;
            }

            right++;
        }

        return minLen == int.MaxValue ? "" : s.Substring(minLeft, minLen);
    }
}