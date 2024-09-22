public class LongestPalindromes
{
    public string LongestPalindrome(string s) {
        if(s.Length == 1)
        return s; 
        int start = 0, end = 0;
        for (int I = 0; I < s.Length; I++)
        {
            int len1 = ExpandAroundCenter(s, I, I);
            int len2 = ExpandAroundCenter(s, I, I + 1);
            int len = Math.Max(len1, len2);
            if(len > end){
                start = I - (len - 1)/2;
                end = I+len/2;
            }
        }
        return s.Substring(start, end - start + 1);
    }

     private int ExpandAroundCenter(string s, int left, int right) {
        while (left >= 0 && right < s.Length && s[left] == s[right]) {
            left--;
            right++;
        }
        return right - left - 1;
    }
}