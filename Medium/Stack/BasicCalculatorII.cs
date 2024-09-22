public class BasicCalculatorII
{
    public int Calculate(string s) {
        if(string.IsNullOrEmpty(s))
        return 0;

        s = s + '+';
        Stack<int> stack = new Stack<int>();
        int result = 0;
        char prevOp = '+';
        int curNum = 0;
        s = s.Replace(" ", "");
        foreach (char ch in s)
        {
            if (ch is >= '0' and <= '9')
            {
                curNum = curNum * 10 + ch - '0';
                continue;
            }

            switch (prevOp)
            {
                case '+':
                    stack.Push(curNum);
                    break;
                case '-':
                    stack.Push(-curNum);
                    break;
                case '*':
                    stack.Push(stack.Pop() * curNum);
                    break;
                case '/':
                    stack.Push(stack.Pop() / curNum);
                    break;
                default:
                    return 0;
            }

            prevOp = ch;
            curNum = 0;
        }
        
        while (stack.Count > 0)
        {
            result += stack.Pop();
        }
        
        return result;    
    }
}