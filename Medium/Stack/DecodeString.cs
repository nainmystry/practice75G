using System.Data.Common;
using System.Text;

public class DecodedString
{

    #region Incorrect Approach
    // public string DecodeString(string s) {
    //     if(string.IsNullOrEmpty(s)) return s;

    //     Stack<char> chars = new Stack<char>();
    //     StringBuilder sb = new StringBuilder();
    //     StringBuilder sb1 = new StringBuilder();
    //     foreach (char c in s)
    //     {
    //         if(c == ']')
    //         {
    //             sb = ComputeString(chars, sb);
    //             if(chars.Count == 0)
    //             {
    //                 sb1.Append(sb);
    //                 sb.Clear();
    //             }
    //         }
    //         else{
    //             chars.Push(c);
    //         }
    //     }  

    //      while(chars.Count > 0)
    //     {
    //         var c = chars.Pop();
    //         sb.Insert(0, c);
    //     }
    //     return sb1.ToString() + sb.ToString();
    // }

    // private StringBuilder ComputeString(Stack<char> chars, StringBuilder sb)
    // {
    //     bool computed = false;
    //     StringBuilder nSB = new StringBuilder();
    //     while(chars.Count > 0)
    //     {
    //         var c = chars.Pop();
    //         if(c == '[' && !computed)
    //         {
    //             var num = chars.Pop();
    //             if(int.TryParse(num.ToString(), out int number))
    //             {
    //                 var str = nSB.ToString() + sb.ToString();
    //                 nSB.Clear();
    //                 for (int i = 0; i < number; i++)
    //                 {
    //                     nSB.Append(str);
    //                 }
    //             }
    //             break;
    //         }
    //         else{
    //             nSB.Insert(0,c);
    //         }
    //     }
    //     return nSB;
    // }

    
    #endregion

    public string DecodeString1(string s)
    {
        Stack<string> strings = new Stack<string>();
        Stack<int> numbers = new Stack<int>();
        string currentString = "";
        int currentNumber = 0;
        foreach (char c in s)
        {
            if (c == '[')
            {
                strings.Push(currentString);
                numbers.Push(currentNumber);
                currentString = "";
                currentNumber = 0;
            }
            else if(c == ']')                    
                currentString = strings.Pop() + string.Join("", Enumerable.Repeat(currentString, numbers.Pop()));                    
            else if ( c-'0'<=9 && c - '0' >= 0)                    
                currentNumber = currentNumber * 10 + (c - '0');                    
            else
                currentString += c;                    
        }
        return currentString;
    }

    int index = 0;
    
    public string DecodeString(string s) 
    {
        var result = new StringBuilder();
        
        while (index < s.Length && s[index] != ']') 
        {
            if (char.IsLetter(s[index]))
                result.Append(s[index++]);
            else {
                int k = 0;
                // build k while next character is a digit
                while (index < s.Length && char.IsDigit(s[index]))
                    k = k * 10 + s[index++] - '0';
                // ignore the opening bracket '['    
                index++;
                string decodedString = DecodeString(s);
                // ignore the closing bracket ']'
                index++;
                // build k[decodedString] and append to the result
                while (k-- > 0)
                    result.Append(decodedString);
            }
        }
        return result.ToString();        
    }
}