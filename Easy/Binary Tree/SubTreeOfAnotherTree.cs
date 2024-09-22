public class SubTreeOfAnotherTree
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot) 
    {
        if(root == null || subRoot == null){
            return root == null && subRoot == null;
        }        
        return SameTree(root, subRoot) || SameTree(root.left, subRoot) || SameTree(root.right, subRoot);
    }

    public bool SameTree(TreeNode first, TreeNode second)
    {
        if (first == null || second == null) return first == null && second == null;
        if (first.val != second.val) return false;
        return SameTree(first.left, second.left) && SameTree(first.right, second.right);
    }


}