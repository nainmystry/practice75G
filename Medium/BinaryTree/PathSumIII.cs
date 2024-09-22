public class PathSumIII
{
    #region Approach 1
    public int PathSum1(TreeNode root, int targetSum) 
    {
        if(root == null) return 0;

        var res = DFS(root, targetSum);
        res += PathSum(root.left, targetSum);
        res += PathSum(root.right, targetSum);
        return res;
    }

    private int DFS(TreeNode node, long targetSum)
    {
        if(node == null) return 0;

        int currentPaths = (node.val == targetSum) ? 1 : 0;
        
        // Continue to check paths including the left and right children
        currentPaths += DFS(node.left, targetSum - node.val);
        currentPaths += DFS(node.right, targetSum - node.val);

        return currentPaths;
    }
    #endregion

    #region  Approach 2
    public int PathSum(TreeNode root, int targetSum)
    {
        Dictionary<long, int> prefixSumCount = new Dictionary<long, int>();
        // Initialize with the base case
        prefixSumCount[0] = 1;
        return PathSumHelper(root, 0, targetSum, prefixSumCount);
    }

    private int PathSumHelper(TreeNode node, long currentSum, long targetSum, Dictionary<long, int> prefixSumCount)
    {
        if (node == null)
        {
            return 0;
        }
        
        // Update the current sum
        currentSum += node.val;
        
        // Get the number of valid paths ending at the current node
        int numPathsToCurrent = 0;
        if (prefixSumCount.ContainsKey(currentSum - targetSum))
        {
            numPathsToCurrent = prefixSumCount[currentSum - targetSum];
        }
        
        // Update the prefixSumCount dictionary
        if (!prefixSumCount.ContainsKey(currentSum))
        {
            prefixSumCount[currentSum] = 0;
        }
        prefixSumCount[currentSum]++;
        
        // Recur for left and right children
        int numPathsInLeftSubtree = PathSumHelper(node.left, currentSum, targetSum, prefixSumCount);
        int numPathsInRightSubtree = PathSumHelper(node.right, currentSum, targetSum, prefixSumCount);
        
        // Backtrack: remove the current sum from the prefixSumCount dictionary
        prefixSumCount[currentSum]--;
        
        return numPathsToCurrent + numPathsInLeftSubtree + numPathsInRightSubtree;
    }


    #endregion
}