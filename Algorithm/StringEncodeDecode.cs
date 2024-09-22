using System.Text;

public class StringEncodeDecode
{
    public string EncodeString(List<string> strs)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in strs)
            {
                //sb.Append(str.Length.ToString("D4")).Append(str);//Decode
                sb.Append(str).Append(str.Length.ToString("D4"));//Decode1
            }
            return sb.ToString();
        }
        catch (System.Exception ex)
        {            
            throw;
        }
    }

    public List<string> DecodeString(string encodedString)
    {
        try
        {
            var res = new List<string>();
            var numRange = 4;
            int i = 0, n = encodedString.Length;
            while(i < n)
            {
                var size = int.Parse(encodedString.Substring(i,numRange));
                res.Add(encodedString.Substring(i + numRange, size));
                i = i + numRange + size;
            }
            return res;
        }
        catch (System.Exception ex)
        {            
            throw;
        }
    }

    public List<string> DecodeString1(string encodedString)
    {
        try
        {
            var res = new List<string>();
            var numRange = 4;
            int n = encodedString.Length;
            for (int i = n; i > 0; )
            {
                var ssr = encodedString.Substring(i - numRange, numRange);
                var size = int.Parse(ssr);
                res.Add(encodedString.Substring(i - (numRange + size), size));
                i = i - (numRange + size);
            }
            return res;
        }
        catch (System.Exception ex)
        {            
            throw;
        }
    }
}