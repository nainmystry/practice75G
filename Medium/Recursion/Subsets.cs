public class Subsets
{

    //Iterative Approach.
    public IList<IList<int>> Subset1(int[] nums) {
        var ans = new List<IList<int>>();
        var intlist = new List<int>();
        ans.Add(intlist);
        if(nums == null || nums.Length == 0)
        {
            return ans;
        }

        for (int I = 0; I < nums.Length; I++)
        {
            int lisCount = ans.Count;
            for (int II = 0; II < lisCount; II++)
            {
                var list = ans[II].ToList();
                list.Add(nums[I]);
                ans.Add(list);
            }
        }

//        ans.Add(nums.ToList());
        return ans;
    }

    //Recursive Backtracking
    public IList<IList<int>> Subset(int[] nums) {
        var result = new List<IList<int>>();
        GenerateSubsets(nums, 0, new List<int>(), result);
        return result;
    }

    private void GenerateSubsets(int[] nums, int index, List<int> current, IList<IList<int>> result){
        result.Add(new List<int>(current));
        for (int I = index; I < nums.Length; I++)
        {
            current.Add(nums[I]);
            GenerateSubsets(nums, I + 1,current,result );
            current.RemoveAt(current.Count - 1);
        }

    }
}