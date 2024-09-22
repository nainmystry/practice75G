using System.Xml;

public class BinaryTreeMaxPathSum
{
    int maxGain = int.MinValue;
    public int MaxPathSum(TreeNode root) {
        DFS(root);
        return maxGain;
    }

    private int DFS(TreeNode root)
    {
        if(root == null)
        return 0;

        //Calculate the left tree sum, recursively
        int leftSum = Math.Max(DFS(root.left), 0);
        //Calculate the right tree sum, recursively
        int rightSum = Math.Max(DFS(root.right), 0);

        //total node sum
        int totalNodeSum = root.val + leftSum + rightSum;

        //Compare with the current maxgain at root level
        maxGain = Math.Max(maxGain, totalNodeSum);

        //whichever sum is higher return that sum.
        return root.val + Math.Max(leftSum, rightSum);
    }
}