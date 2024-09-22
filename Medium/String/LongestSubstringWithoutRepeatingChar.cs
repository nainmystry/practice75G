public class LongestSubstringWithoutRepeatingChar
{

    /*
    Iterative Approach
    - create hashset, store char in it. If the hashset contains char, break loop, check the length
    - Iterate over whole N (string length)
    */
    public int LengthOfLongestSubstringI(string s) {
        int longestString = 0;        
        for(int I = 0; I < s.Length; I++){
            HashSet<char> chars = new HashSet<char>();
            chars.Add(s[I]);
            for (int II = I+1; II < s.Length; II++)
            {
                if(chars.Contains(s[II])){
                    break;
                }
                else{
                    chars.Add(s[II]);
                }
            }
            longestString = Math.Max(longestString, chars.Count);
        }
        return longestString;
    }

/*
Sliding Window Approach (Faster/Optimised)
- take 2 pointer i,j & a hashset to store chars
- with i being the start and j incrementing, check if char at j is already present in hashset
  If not present, then add it & update maxLength with (J - I + 1). (compare the new max with the existing max and take greater one).
  Else, remove that char from hashset & increment i 
*/
    public int LengthOfLongestSubstring(string s) {
        int i = 0, j = 0, res = 0;
        int N = s.Length;        
        HashSet<char> chars = new HashSet<char>();
        while(i < N && j < N){
            if(!chars.Contains(s[j])){
                chars.Add(s[j]);
                res = Math.Max(res, (j - i + 1));
                j++;
            }
            else{
                chars.Remove(s[i]);
                i++;
            }
        }
        return res;

    }
}