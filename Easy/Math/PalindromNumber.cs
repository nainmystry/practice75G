public class PalindromNumber
{
    public bool IsPalindrome(int x) {
        if (x < 0 || (x % 10 == 0 && x != 0))
        {
            return false;
        }
        int reversed = 0;
        int original = x;

        // Reverse the integer
        while (x > 0)
        {
            int digit = x % 10;  // Extract the last digit
            reversed = reversed * 10 + digit;  // Append digit to the reversed number
            x /= 10;  // Remove the last digit
        }

        // Check if the reversed number is equal to the original
        return original == reversed;
    }
}