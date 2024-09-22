using System.Text;

public class LargestNumbers
{
    // public string LargestNumber(int[] nums) {
    //     if(nums.Length == 0) return "";
    //     if(nums.Length == 1) return nums.First().ToString();

    //     string max = "";
    //     StringBuilder sb = new StringBuilder();
    //     StringBuilder sb1 = new StringBuilder();
    //     var strArra = nums.Select(x => x.ToString()).ToList();
    //     strArra.Sort();

    //     for (int I = 0; I < nums.Length; I++)
    //     {
    //         if(I == 0)
    //         {
    //             max = nums[0].ToString();
    //             continue;
    //         }
    //         sb.Append(max + nums[I].ToString());
    //         sb1.Append(nums[I].ToString() + max);
    //         var newMax = Math.Max(double.Parse(sb.ToString()),double.Parse(sb1.ToString()));
    //         max = newMax.ToString();
    //         sb.Clear();
    //         sb1.Clear();
    //     }
    //     return max;
    // }

    public string LargestNumber(int[] nums)
    {
        var rres = nums.OrderByDescending(x => x.ToString(), new MyComparer());
        string result = string.Join("", rres);
    
        return result[0] == '0' ? "0" : result;
    }
    public class MyComparer : IComparer<string>
    {
        public int Compare(string stringA, string stringB)
        {
            return (stringA + stringB).CompareTo(stringB + stringA);
        }
    }
}