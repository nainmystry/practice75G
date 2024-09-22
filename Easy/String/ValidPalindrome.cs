using System.Text.RegularExpressions;

public class Palindrome {
    public bool IsPalindrome(string s) {
        bool isPalindrome = false;
        if(string.IsNullOrEmpty(s)){
            return !isPalindrome;
        }

        var resString = Regex.Replace(s,"[^a-zA-Z]","").ToLower();

        if(string.IsNullOrEmpty(resString) || resString.Count() == 1){
            return !isPalindrome;
        }
        int N = resString.Count();
        for (int I = 0; I < N/2; I++)
        {
            var vaal = (N-1)-I;
            var ka = resString[I];
            var ak =  resString[vaal];
            if(resString[I] != resString[(N-1)-I]){
                isPalindrome = true;
                break;
            }
        }

        return !isPalindrome;
    }
}