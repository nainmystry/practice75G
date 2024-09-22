public class LetterCombinationOfAPhoneNumber
{
    private static readonly Dictionary<char, string> phoneMap = new Dictionary<char, string> {
        { '2', "abc" }, { '3', "def" }, { '4', "ghi" }, { '5', "jkl" },
        { '6', "mno" }, { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" }
    };
    
    public IList<string> LetterCombinations(string digits) {
        IList<string> result = new List<string>();
        if (string.IsNullOrEmpty(digits)) return result;
        
        Backtrack(result, digits, 0, new List<char>());
        return result;
    }
    
    private void Backtrack(IList<string> result, string digits, int index, List<char> current) {
        if (index == digits.Length) {
            result.Add(new string(current.ToArray()));
            return;
        }
        
        string possibleLetters = phoneMap[digits[index]];
        foreach (char letter in possibleLetters) {
            current.Add(letter);
            Backtrack(result, digits, index + 1, current);
            current.RemoveAt(current.Count - 1); // Backtrack
        }
    }
}