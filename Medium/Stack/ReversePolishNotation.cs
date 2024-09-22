public class EvalRPNSolution {
    
    public int EvalRPN(string[] tokens) {
        Stack<int> ints = new();
        int a = 0;
        int b = 0;
        for (int I = 0; I < tokens.Length; I++)
        {
            var token = tokens[I];   
            switch (token)
            {
                case "+":
                    b = ints.Pop();
                    a = ints.Pop();
                    ints.Push(a + b);
                    break;
                case "-":
                    b = ints.Pop();
                    a = ints.Pop();
                    ints.Push(a - b);
                    break;
                case "*":
                    b = ints.Pop();
                    a = ints.Pop();
                    ints.Push(a * b);
                    break;
                case "/":
                    b = ints.Pop();
                    a = ints.Pop();
                    ints.Push(a / b);
                    break;
                default:
                    ints.Push(Convert.ToInt32(token));
                    break;
            }
        }
        return ints.Peek();
    }
}