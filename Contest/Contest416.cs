public class Contest416
{   
    public bool ReportSpam(string[] message, string[] bannedWords) {
        HashSet<string> bannedSet = new HashSet<string>(bannedWords);
        
        int count = 0; 
        
        foreach (var word in message)
        {
        
            if (bannedSet.Contains(word))
            {
                count++; 
                if (count >= 2)
                {
                    return true; 
                }
            }
        }
        return false;
    }

    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes) {
        long left = 0;
        long right = (long)mountainHeight * (mountainHeight + 1) / 2 * workerTimes[0];

        // Estimate maximum time required
        foreach (var time in workerTimes)
        {
            long maxTime = (long)mountainHeight * (mountainHeight + 1) / 2 * time;
            right = Math.Min(right, maxTime);
        }

        long result = right;

        while (left <= right)
        {
            long mid = left + (right - left) / 2;

            if (CanReduceHeight(mid, mountainHeight, workerTimes))
            {
                result = mid; // Found a possible solution
                right = mid - 1; // Try for less time
            }
            else
            {
                left = mid + 1; // Increase time
            }
        }

        return result;
    }

    private static bool CanReduceHeight(long time, int mountainHeight, int[] workerTimes)
    {
        long totalReduced = 0;

        foreach (var workerTime in workerTimes)
        {
            // Calculate maximum units that can be reduced by this worker in 'time'
            long left = 0, right = mountainHeight;

            while (left < right)
            {
                long mid = (left + right + 1) / 2; // Upper mid
                long totalTimeForMid = workerTime * mid * (mid + 1) / 2;

                if (totalTimeForMid <= time)
                {
                    left = mid; // Can reduce this many units
                }
                else
                {
                    right = mid - 1; // Reduce the number of units
                }
            }

            totalReduced += left; // Add the maximum units this worker can reduce

            if (totalReduced >= mountainHeight) return true; // Sufficient height reduced
        }

        return totalReduced >= mountainHeight; // Final check
    }

    public long ValidSubstringCount(string word1, string word2) {
        int m = word1.Length;
        int n = word2.Length;

        if (n > m) return 0; // If word2 is longer than word1, no valid substrings

        // Frequency arrays for characters (assuming lowercase 'a' to 'z')
        int[] freqWord2 = new int[26];
        int[] freqWindow = new int[26];

        // Count frequency of characters in word2
         foreach (char c in word2)
        {
            freqWord2[c - 'a']++;
        }

        // Initialize the valid count
        int validCount = 0;

        // Slide through word1 with different lengths starting from n
        for (int start = 0; start <= m - n; start++)
        {
            // Reset the window frequency array
            Array.Clear(freqWindow, 0, 26);
            // Fill the window with characters from the substring
            for (int end = start; end < m; end++)
            {
                freqWindow[word1[end] - 'a']++;

                // Check if the current window can be rearranged to have word2 as a prefix
                if (end - start + 1 >= n && IsValid(freqWindow, freqWord2))
                {
                    validCount++;
                }
            }
        }

        return validCount;
    }

    private static bool IsValid(int[] freqWindow, int[] freqWord2)
    {
        for (int i = 0; i < 26; i++)
        {
            if (freqWindow[i] < freqWord2[i]) return false;
        }
        return true;
    }
}