public class LongestRepeatingCharReplacement
{
    public int CharacterReplacement(string s, int k) {
        int left = 0;
        int[] freq = new int[26];
        int maxCount = 0, maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            freq[s[right] - 'A']++;
            maxCount = Math.Max(maxCount, freq[s[right] - 'A']);

            int changes = (right - left + 1) - maxCount;

            if(changes > k)
            {
                freq[s[right] - 'A']--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }
        return maxLength;
    }
}