public class SymmetricTree
{
    public bool IsSymmetric(TreeNode root) {
        return CheckSymmetry(root?.left, root?.right);
    }

    private bool CheckSymmetry(TreeNode left, TreeNode right)
    {
        if(left == null || right == null)
            return left?.val == right?.val;

        if(left.val != right.val)
            return false;

        return CheckSymmetry(left.left, right.right) && CheckSymmetry(left.right, right.left);
    }

    
}