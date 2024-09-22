using System.Diagnostics.CodeAnalysis;

public class PathSumII
{

    //root-to-leaf path. 
    //leaf node = node.left == null && node.right == null.
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        List<IList<int>> ints = new List<IList<int>>();
        if(root == null)
        {
            return ints;
        }

        Queue<(TreeNode, List<int>)> que = new Queue<(TreeNode, List<int>)>();
        que.Enqueue((root, new List<int>()));

        while(que.Count > 0)
        {
            (var node, List<int> ints1)= que.Dequeue();
            ints1.Add(node.val);
            int sum = ints1.Sum();
            if(node.left == null && node.right == null && sum == targetSum)
            {
                ints.Add(new List<int>(ints1));
                continue;
            } 

            if(node.left != null)
            {
                que.Enqueue((node.left, new List<int>(ints1)));
            }

            if(node.right != null)
            {
                que.Enqueue((node.right, new List<int>(ints1)));
            }
        }

        return ints;

    }

    //Recursion Approach
    public IList<IList<int>> PathSumRec(TreeNode root, int targetSum) {
        IList<IList<int>> paths = new List<IList<int>>();

        if (root == null)
            return paths;
        
        CheckDeeper(root, targetSum, 0, new List<int>(), ref paths);
        return paths;
    }

    void CheckDeeper(TreeNode root, int targetSum, int sum, List<int> path, ref IList<IList<int>> results)
    {
        path.Add(root.val);
        sum += root.val;

        if (sum == targetSum && root.left == null && root.right == null)
            results.Add(new List<int>(path));

        if (root.left != null)
            CheckDeeper(root.left, targetSum, sum, path, ref results);
        if (root.right != null)
            CheckDeeper(root.right, targetSum, sum, path, ref results);
        
        path.RemoveAt(path.Count - 1);
    }    
}