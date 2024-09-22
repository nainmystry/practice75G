public class PalindromePaires
{
    public IList<IList<int>> PalindromePairs(string[] words) {
        bool isPalindrome(string s, int start, int end) {
            while (start < end) {
                if (s[start] != s[end]) {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }

        string reverse(string s) {
            var charArr = s.ToCharArray();
            Array.Reverse(charArr);
            return new string(charArr);
        }

        IDictionary<string, int> reverseMap = new Dictionary<string, int>(words.Length);
        ISet<int> wordSizeSet = new HashSet<int>(words.Length);
        for (int index = 0; index < words.Length; index++) {
            reverseMap.Add(reverse(words[index]), index);
            wordSizeSet.Add(words[index].Length);
        }

        IList<IList<int>> answer = new List<IList<int>>();
        for (int index = 0; index < words.Length; index++)
        {
            string word = words[index];
            if(reverseMap.ContainsKey(word) && index != reverseMap[word])
            {
                answer.Add(new List<int>() {index, reverseMap[word]});
            }

            foreach (int size in wordSizeSet)
            {
                if(size >= word.Length) continue;
                if (isPalindrome(word, 0, word.Length - 1 - size)) {
                    string right = word.Substring(word.Length - size);
                    if (reverseMap.ContainsKey(right)) {
                        answer.Add(new List<int>() {reverseMap[right], index});
                    }
                }
                if (isPalindrome(word, size, word.Length - 1)) {
                    string left = word.Substring(0, size);
                    if (reverseMap.ContainsKey(left)) {
                        answer.Add(new List<int>() {index, reverseMap[left]});
                    }
                }
            }
        }
        return answer;

    }
}