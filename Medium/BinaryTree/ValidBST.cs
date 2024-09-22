using System.Runtime.CompilerServices;

public class ValidBST {

/*
 Conditions for a Binary Tree to qualify as Binary Search Tree (BST):
The left child’s key is less than the key of its parent.
The right child’s key is more than the key of its parent.
The left and right subtrees also count as BST individually.
*/   

    //Approach1 with Min & Max values
    public bool IsValidBST(TreeNode root) {
        return CheckBinaryTree(root, long.MinValue, long.MaxValue);
    }
    
    private bool CheckBinaryTree(TreeNode node, long min, long max){
        if(node == null) return true;

        if(node.val <= min || node.val >= max) return false;

        if(CheckBinaryTree(node.left, min, node.val) && CheckBinaryTree(node.right, node.val, max)){
            return true;
        }

        return false;
    }

    //Approach 2 Inorder traversal
    public bool IsValidBST2(TreeNode root) {
        TreeNode prev = null;
        return IsBST(root, ref prev);
    }
    
    private bool IsBST(TreeNode root, ref TreeNode prev)
    {
        if (root == null)
            return true;

        if (!IsBST(root.left, ref prev))
            return false;

        if (prev != null && root.val <= prev.val)
            return false;

        prev = root;

        return IsBST(root.right, ref prev);
    }
}