public class ReverseInteger
{
    public int Reverse1(int x)
    {
        int reversed = 0;
        int intMax = int.MaxValue;
        int intMin = int.MinValue;

        while (x != 0)
        {
            int digit = x % 10;

            // Check for overflow before multiplying by 10 and adding digit
            if (reversed > intMax / 10 || (reversed == intMax / 10 && digit > intMax % 10))
            {
                return 0; // Will overflow, return 0
            }
            if (reversed < intMin / 10 || (reversed == intMin / 10 && digit < intMin % 10))
            {
                return 0; // Will underflow, return 0
            }

            reversed = reversed * 10 + digit;
            x /= 10;
        }

        return reversed;
    }

    public int Reverse(int x) {
        int coefficient = 1;

        int[] coefficients = new int[10];
        for (int i = 1; i < 11; i++)
        {
            coefficients[i - 1] = coefficient;
            coefficient *= 10;
        }

        int[] numbers = new int[10];

        int j = 0;

        int index = x;
        while (index != 0)
        {
            numbers[j] = index % 10;
            j++;

            index /= 10;
        }

        int t = j;

        int number = 0;
        for (int i = 0; i < j; i++)
        {
            int num = numbers[i];
            
            if (j == 10)
            {
                try
                {
                    number = checked(number + num * coefficients[--t]);
                }
                catch (OverflowException)
                {
                    return 0;
                }

                continue;
            }

            number += num * coefficients[--t];
        }

        return number;
    }

}