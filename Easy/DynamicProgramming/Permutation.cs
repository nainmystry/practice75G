public class Permutation
{
    public IList<IList<int>> Permute2(int[] nums)
    {
        IList<IList<int>> ans = new List<IList<int>> ();
        //if(nums == null || nums.Length == 0)
            
        return ans;
        
        // int facto = 1, n = nums.Length;
        // if(nums.Length == 1)
        // {
        //     var ls = nums.ToList();
        //     ans.Add(ls);
        //     return ans;
        // }

        // if(n == 2) facto = 2;
        // if(n == 3) facto = 6;
        // if(n == 4) facto = 24;
        // if(n == 5) facto = 120;
        // if(n == 6) facto = 720;

        // int[][] ints = new int[facto][];
        // ints[0] = nums;
        // for (int I = 1; I < n; I++)
        // {
        //     ints[I][0] = nums[0];
        //     for (int II = 1; II < n; II++)
        //     {
        //         ints[I][II] = nums[II];
        //     }
            
        // }
    }

    public void shiftOneStep(int[] nums, int ind)
    {

    }

    public IList<IList<int>> Permute(int[] nums) {
        var result = new List<IList<int>>();
        var queue = new Queue<List<int>>();
        queue.Enqueue(new List<int>());
        
        for(int i=0;i<nums.Length;i++)
        {
            int size = queue.Count;
            for(int j=0;j<size;j++)
            {
                var curr = queue.Dequeue(); // get latest list
                for(int k=0;k<=curr.Count;k++) // add it into every single index
                {
                    var temp = new List<int>(curr); // take a copy
                    temp.Insert(k, nums[i]); // insert at index
                    queue.Enqueue(temp);
                }
            }
        }
        
        while(queue.Count > 0)
            result.Add(queue.Dequeue());
        
        return result;
    }
}