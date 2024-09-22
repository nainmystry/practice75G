using System.Text;

public class WContest411
{
    public long MaxEnergyBoost1(int[] energyDrinkA, int[] energyDrinkB) {        
        int eS = 0;
        int[] dp = new int[energyDrinkA.Length];
        bool switched = false;
        for (int I = 0; I < energyDrinkA.Length; I++)
        {
            if(I == 0)
            {
            if(energyDrinkA[I] > energyDrinkB[I])
            {
                eS = energyDrinkA[I];
            }
            else{
                eS = energyDrinkB[I];
                switched = true;
            }
            continue;
            }


            if(switched && energyDrinkA[I] > energyDrinkB[I])
            {
                var eIntermittent = eS - energyDrinkB[I - 1];
                if(eIntermittent + energyDrinkA[I] > eS)
                {
                    switched = false;
                    eS = eIntermittent + energyDrinkA[I];
                }
            }
            else{
                if(!switched)
                eS += energyDrinkA[I];                 
            }

            if(energyDrinkA[I] < energyDrinkB[I] && !switched)
            {
                var eIntermittent = eS - energyDrinkA[I - 1] - energyDrinkA[I];
                if(eIntermittent + energyDrinkB[I] > eS)
                {
                    switched = true;
                    eS = eIntermittent + energyDrinkB[I];
                }
            }
            else{
                if(switched)
                {
                eS += energyDrinkB[I];
                }
            }
        }
        return eS;

    }

    //dp
    public long MaxEnergyBoost(int[] energyDrinkA, int[] energyDrinkB) 
    {
        int N = energyDrinkA.Length;

        if (N == 0)
            return 0;

        if (N == 1)
            return Math.Max(energyDrinkA[0], energyDrinkB[0]);

        long pA = energyDrinkA[0];
        long pB = energyDrinkB[0];

        long ppA = 0;
        long ppB = 0;

        for (int I = 1; I < N; I++)
        {
            long currentA = energyDrinkA[I] + Math.Max(pA, (I > 1 ? ppB : 0));
            long currentB = energyDrinkB[I] + Math.Max(pB, (I > 1 ? ppA : 0));
         
            ppA = pA;
            ppB = pB;
            pA = currentA;
            pB = currentB;
        }
        return Math.Max(pA, pB);
    }

    public string LargestKPalindromic(int n, int k)
    {
        // Determine how many digits we need to control (half of the palindrome)
        int halfLength = (n + 1) / 2;

        // Generate the largest half by filling it with 9's
        StringBuilder half = new StringBuilder();
        for (int i = 0; i < halfLength; i++)
        {
            half.Append('9');
        }

        // Convert the half to a number
        long halfNum = long.Parse(half.ToString());

        // Try generating palindromes starting from the largest half and decrementing
        while (halfNum > 0)
        {
            // Generate the full palindrome based on the half
            string palindrome = GeneratePalindrome(halfNum, n % 2 == 1);

            // Check if the palindrome is divisible by k
            if (long.Parse(palindrome) % k == 0)
            {
                return palindrome;
            }

            // Decrement the half and try again
            halfNum--;
        }

        // If no palindrome is found (shouldn't happen for reasonable k), return an empty string
        return "";
    }

    // Helper function to generate a full palindrome from a half
    private string GeneratePalindrome(long halfNum, bool isOddLength)
    {
        string halfStr = halfNum.ToString();
        StringBuilder palindrome = new StringBuilder(halfStr);

        // If the length is odd, we don't repeat the middle digit
        int start = isOddLength ? halfStr.Length - 2 : halfStr.Length - 1;

        // Mirror the half to generate the full palindrome
        for (int i = start; i >= 0; i--)
        {
            palindrome.Append(halfStr[i]);
        }

        return palindrome.ToString();
    }

    public string LargestPalindrome1(int n, int k) {
        if(k == 1)
        return new string('9',n);

        char[] palindrome = new char[n];
        for (int i = 0; i < n; i++)
        {
            palindrome[i] = '9';
        }   

        while (true)
        {
            if (IsDivisibleByK(palindrome, k))
            {
                return new string(palindrome); // Return the palindrome as a string
            }

            // Step 3: Decrement the palindrome
            DecrementPalindrome(palindrome, n);
        }
    }

    private bool IsDivisibleByK(char[] palindrome, int k)
    {
        long number = 0;
        foreach (char digit in palindrome)
        {
            number = number * 10 + (digit - '0'); // Convert char array to number
            number %= k; // Only care about the remainder
        }
        return number == 0;
    }

    // Helper function to decrement the palindrome efficiently
    private void DecrementPalindrome(char[] palindrome, int n)
    {
        int half = (n + 1) / 2;

        // Decrement the first half
        for (int i = half - 1; i >= 0; i--)
        {
            if (palindrome[i] > '0')
            {
                palindrome[i]--; // Decrement the current digit
                break;
            }
            else
            {
                palindrome[i] = '9'; // Carry over if we hit zero
            }
        }

        // Mirror the first half into the second half to maintain the palindrome property
        for (int i = 0; i < half; i++)
        {
            palindrome[n - 1 - i] = palindrome[i];
        }
    }

    //sliding window approach
    public int CountSubstringsWithKConstraint(string s, int k)
    {
        int n = s.Length;
        int count = 0;

        // Iterate over all possible starting points of substrings
        for (int left = 0; left < n; left++)
        {
            int zeroCount = 0, oneCount = 0;

            // Expand the window with the right pointer
            for (int right = left; right < n; right++)
            {
                // Update the count of 0's and 1's
                if (s[right] == '0')
                    zeroCount++;
                else
                    oneCount++;

                // Check if the current substring satisfies the k-constraint
                if (zeroCount <= k || oneCount <= k)
                {
                    count++;  // This substring is valid, increment the count
                }
                else
                {
                    break;  // If it doesn't satisfy, stop expanding this substring
                }
            }
        }

        return count;
        // int count0 = CountValidSubstrings(s, k, '0');
        // int count1 = CountValidSubstrings(s, k, '1');
        // return count0 + count1;
    }

    private int CountValidSubstrings(string s, int k, char ch)
    {
        int N = s.Length;
        int left = 0, count = 0, charCount = 0;

        for (int right = 0; right < N; right++)
        {
            if (s[right] == ch)
            {
                charCount++;  
            }

            while (charCount > k)
            {
                if (s[left] == ch)
                {
                    charCount--;  
                }
                left++;  
            }
            count += (right - left + 1);
        }

        return count;
    }
}