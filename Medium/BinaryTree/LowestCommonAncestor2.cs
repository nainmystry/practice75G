public class LowestCommonAncestor2
{
    /*
    There are only (3) possible scenarios for the answer:
        p is located in the left subtree and q is located in the right subtree
        q is located in the left subtree and p is located in the right subtree
        p and q are located in the left subtree OR p and q are located in the right subtree
        If p and q are located in the same subtree, then you can just return p or q, whichever node was found.

        r1 == null return r2
        OR
        r2 == null return r1
        If p and q are in both the left subtree and the right subtree then return the "closet" parent node.
        r1 and r2 == null return root
    Approach
        If the node being checked is null then return null. This covers when node.left is null or node.right is null.
        If the node being checked is equal to p or q then return the node.
        Recursive call to evaluate node.left. Need to capture return value.
        Recursive call to evaluate node.right. Need to capture return value.
        If both recursive calls return values that are not null then return the node itself. This means that p and q are in both the left and right subtrees.
        Otherwise return the result of the first recursive call. This means that both p and q were found in the left subtree. If the first call returns null then return the result from the second recursive call. This means both p and q were found in the right subtree.
    */
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(root == null){return null;}

        if(root == p || root == q){return root;}

        var r1 = LowestCommonAncestor(root.left, p, q);
        var r2 = LowestCommonAncestor(root.right, p, q);

        if(r1 != null && r2 != null) return root;

        return r1 ?? r2;     
    }
}