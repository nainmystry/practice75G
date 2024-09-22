public class BasicCalculator
{
    public int Calculate1(string s) {
        // Remove all spaces for simplicity
        s = s.Replace(" ", "");

        // Stack to hold numbers and operators
        Stack<int> numbers = new Stack<int>();
        Stack<char> operators = new Stack<char>();

        int number = 0;
        char operation = '+';

        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];

            if (char.IsDigit(ch))
            {
                number = number * 10 + (ch - '0');
            }

            if (ch == '(')
            {
                // Push the current state onto the stack
                numbers.Push(number);
                operators.Push(operation);
                number = 0;
                operation = '+';
            }
            else if (ch == ')')
            {
                // Resolve the expression within parentheses
                number = ApplyOperation(numbers.Pop(), number, operators.Pop());
            }
            else if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
            {
                // Apply previous operations if needed
                number = ApplyOperation(numbers.Count > 0 ? numbers.Pop() : 0, number, operation);
                
                // Store current operator and reset number
                operation = ch;
                number = 0;
            }
        }
        
        var result = ApplyOperation(numbers.Count > 0 ? numbers.Pop() : 0, number, operation);

        return result;
    }

    private int ApplyOperation(int left, int right, char op)
    {
        switch (op)
        {
            case '+': return left + right;
            case '-': return left - right;
            case '*': return left * right;
            case '/': return left / right;
            default: throw new InvalidOperationException("Invalid operator");
        }
    }

    public int Calculate(string s)
    {
        s = string.Join("", s.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        i = 0;
        return CalculateAux(s);
    }

    private int i = 0;
    private int CalculateAux(string s) {
        int result = 0;
        int sign = 1;
        for (; i < s.Length; ++i) {
            switch (s[i]) {
                case '+': break;
                case '-':
                    sign = -1;
                    break;
                case '(':
                    ++i;
                    result += CalculateAux(s) * sign;
                    sign = 1;
                    break;
                case ')':
                    return result;
                default:
                    int tmp = int.Parse(s[i].ToString());
                    while (i + 1 < s.Length && char.IsDigit(s[i + 1])) {
                        tmp = (tmp * 10) + int.Parse(s[++i].ToString());
                    }
                    result += tmp * sign;
                    sign = 1;
                    break;
            }
        }

        return result;
    }  
}