using System.Text;

public class Contest417
{
    public char KthCharacter(int k) {
        StringBuilder outputString = new StringBuilder();
        char[] charArray = new char[26];
        charArray = createCharArray();
        outputString.Append('a');
        while(outputString.Length < k)
        {
            var dystring = outputString.ToString();
            foreach (char item in dystring)
            {
                outputString.Append(getNextChar(item, charArray));
            } 
        }    
        var res = outputString.ToString();     
        return outputString[k - 1];
    }

    private char[] createCharArray()
    {
       char start = 'a';
        char[] chars = new char[26]; 
        for (int i = 0; i < 26; i++)
        {
            chars[i] = start;
            start++; 
        }
        return chars;
    }

    private char getNextChar(char a, char[] charArray)
    {
        
        if(a == 'z')
        {
            return 'a';
        }
        else{
            int index = a - 'a' + 1; 
            return charArray[index];       
        }
    }


    public int CountOfSubstrings(string s, int k) {
        int count = 0;
        int n = s.Length;
        Dictionary<char, int> vowelCount = new Dictionary<char, int>();
        int consonantCount = 0;
        if(n < 5 + k)
        return count;
        for (int start = 0; start < n; start++)
        {
            // Reset counts for the new start position
            vowelCount.Clear();
            consonantCount = 0;

            for (int end = start; end < n; end++)
            {
                char currentChar = s[end];

                // Check if it's a vowel
                if ("aeiou".Contains(currentChar))
                {
                    if (vowelCount.ContainsKey(currentChar))
                    {
                        vowelCount[currentChar]++;
                    }
                    else
                    {
                        vowelCount[currentChar] = 1;
                    }
                }
                else if (char.IsLetter(currentChar)) // Check if it's a consonant
                {
                    consonantCount++;
                    if(consonantCount > k)
                    {
                        break;
                    }
                }

                // Check if we have exactly one of each vowel and at least k consonants
                if (vowelCount.Count == 5 && consonantCount == k)
                {
                    count++;
                }
            }
        }

        return count;              
    }

    public long CountOfSubstrings2(string word, int k)
    {
        int n = word.Length;
        long count = 0;
        
        if (n < 5 + k)
            return count;

        Dictionary<char, int> vowelCount = new Dictionary<char, int>();
        int consonantCount = 0;
        int start = 0;

        for (int end = 0; end < n; end++)
        {
            char currentChar = word[end];

            // Update counts based on the current character
            if ("aeiou".Contains(currentChar))
            {
                if (vowelCount.ContainsKey(currentChar))
                {
                    vowelCount[currentChar]++;
                }
                else
                {
                    vowelCount[currentChar] = 1;
                }
            }
            else if (char.IsLetter(currentChar))
            {
                consonantCount++;
            }

            
            // Maintain valid window
            while (vowelCount.Count > 5 && consonantCount > k)
            {
                char startChar = word[start];
                if ("aeiou".Contains(startChar))
                {
                    if (vowelCount.ContainsKey(startChar))
                    {
                        vowelCount[startChar]--;
                        if (vowelCount[startChar] == 0)
                        {
                            vowelCount.Remove(startChar);
                        }
                    }
                }
                else if (char.IsLetter(startChar))
                {
                    consonantCount--;
                }
                start++; // Move the start pointer
            }

            // Check if we have exactly 5 vowels and k consonants
            if (vowelCount.Count == 5 && consonantCount == k)
            {
                // Since we need to count all valid substrings starting from `start`
                count += (start + 1);
            }

            
        }

        return count;
    }

}