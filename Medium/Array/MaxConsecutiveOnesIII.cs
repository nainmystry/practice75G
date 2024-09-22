
public class MaxConsecutiveOnesIII {

    //Revise
    //toughest
    public int LongestConsecutiveOnes(string str, int k) {
        int l = 0, r = 0;
        int len = 0, ans = 0, consZ = 0;
        int n = str.Length; // Length of the string

        while (r < n) {
            // If current character is '1', update length and move right pointer
            if (str[r] == '1') {
                len++;
                r++;
                ans = Math.Max(ans, len);
                continue;
            }

            // If current character is '0', count consecutive zeros
            while (r < n && str[r] == '0') {
                len++;
                r++;
            }
            consZ++;

            // If more than k groups of consecutive zeros taken, remove leftmost group
            if (consZ > k) {
                bool flag = false;
                while (l <= Math.Min(r, n - 1)) {
                    if (flag && str[l] == '1') {
                        consZ--;
                        break;
                    }
                    if (str[l] == '0') {
                        flag = true;
                    }
                    l++;
                    len--;
                }
            }

            // Update maximum length of consecutive 1's encountered
            ans = Math.Max(ans, len);
        }

        return ans;
    }
}
