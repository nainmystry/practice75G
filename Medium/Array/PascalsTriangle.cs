public class PascalsTriangle
{
    /*
    
    Given an integer numRows, return the first numRows of Pascal's triangle.
    In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
    Pascal Formula = n! / r! * (n - r)!
                    
    */

    //using pascal's formula
    public IList<IList<int>> Generate2(int numRows) {
        IList<IList<int>> valw = new List<IList<int>>();
        for (int i = 1; i <= numRows; i++)
        {
            valw.Add(CalculateValue(i));
        }
        return valw;
    }

    private IList<int> CalculateValue(int row)
    {
        long ans = 1;
        List<int> ansList = new List<int>();
        ansList.Add(1);

        for (int col = 1; col < row; col++)
        {
            ans = ans * (row - col);
            ans = ans / col;
            ansList.Add((int)ans);
        }
        return ansList;
    }

    //optimized approach to print whole triangle
     public IList<IList<int>> Generate(int numRows) 
    {
        IList<IList<int>> result = new List<IList<int>>();
        if(numRows>=1)
        {
            result.Add(new List<int> { 1 });
        }
        for(int i = 1; i<numRows; i++)
        {
            IList<int> prev =new List<int>(result[i-1]);
            IList<int> cur = new List<int>(){1};
            for(int j = 1; j < i; j++)
            {
                cur.Add(prev[j-1]+prev[j]);
            }
            cur.Add(1);
            result.Add(cur);
        }
        return result;
    }
}