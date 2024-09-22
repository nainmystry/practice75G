
using Microsoft.VisualBasic;

public class CombinationSum
{
    //Recurrsion
    public IList<IList<int>> Combinationsum(int[] candidates, int target) {
        IList<IList<int>> ans = new List<IList<int>>();
        findCombinations(0, candidates, target, ans, new List<int>());
        return ans;
    }

    private void findCombinations(int ind, int[] candidates, int target, IList<IList<int>> ans, List<int> list)
    {
        try
        {
            if(ind == candidates.Length)
            {
                if(target == 0)
                {
                    if(list != null){
                        List<int> newlist = list.ToList();
                        ans.Add(newlist);
                    }
                }
                return;
            }

            if (candidates[ind] <= target) 
            {
                list.Add(candidates[ind]);
                findCombinations(ind, candidates, target - candidates[ind], ans, list);
                list.RemoveAt(list.Count - 1);
            }
            findCombinations(ind + 1, candidates, target, ans, list);
        }
        catch (System.Exception ex)
        {
            
            throw;
        }
    }

    public IList<IList<int>> CombinationSum2(int[] candidates, int target) 
    {

      IList<IList<int>> res = new List<IList<int>>();
      Dfs(0,candidates,0,target,res,new List<int>());
      return res;
    }

    //Example of backtracking
    private void Dfs(int index, int[] candidates, int total, int target, IList<IList<int>> res,List<int> curr)
    {
        if(total == target)
        {
          res.Add(curr.ToList());
          return;
        }

        if(index >= candidates.Length || total > target)
          return;

        curr.Add(candidates[index]);

        Dfs(index,candidates,total+candidates[index],target,res,curr);
        curr.Remove(candidates[index]);
        Dfs(index+1,candidates,total,target,res,curr);
    }

    private void Recursion(int index, int[] candidates, int target, int total, IList<IList<int>> ans, List<int> list)
    {
        if(total == target)
        {
            ans.Add(list.ToList());
            return;
        }

        if(total > target || index == candidates.Length)
        return;

        list.Add(candidates[index]);
        Recursion(index, candidates, target, total + candidates[index],ans,list);
        list.Remove(candidates[index]);
        Recursion(index+1, candidates,target,total,ans,list);
    }

    private void Recursion1(int index, int[] candidates, int target, IList<IList<int>> ans, List<int> list)
    {
        if(index == candidates.Length)
        {
            if(target == 0)
            {
                ans.Add(list.ToList());
                return;
            }
        }

        if(candidates[index] <= target)
        {
            list.Add(candidates[index]);
            Recursion1(index,candidates,target - candidates[index],ans,list);
            list.Remove(candidates[index]);
        }
        Recursion1(index+1,candidates,target,ans,list);
    }

}