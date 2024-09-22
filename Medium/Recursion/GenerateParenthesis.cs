using System.Text;

public class GenerateParenthes
{
    public IList<string> GenerateParenthesis(int n) {
        List<string> result = new List<string>();        
        ResursiveCall(n, "", 0,0, result);
        return result;
    }

    private void ResursiveCall(int n, string str, int openInd, int closeInd, List<string> res)
    {
        if(str.Length == n * 2)
        {
            res.Add(str.ToString());
        }

        if(openInd < n)
        ResursiveCall(n, str + "(", openInd + 1, closeInd, res);

        if(closeInd < openInd)
        ResursiveCall(n, str + ")", openInd, closeInd + 1, res);
    }
}