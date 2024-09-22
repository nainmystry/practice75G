public class InorderSuccessorInBST
{
    //Revise
    // Function to find the inorder successor
    // of a node in a BST
    //In a BST, as per principle, if the value of is P is less than root, navigate right
    //else navigate right
    //to get the successor, update when navigating to left
    // for predecessor update the predecessor, when navigating right.
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        TreeNode successor = null;
        // Traverse until root is not null
        while (root != null) {
            // If the value of p is greater or equal
            // to the current root's value
            if (p.val >= root.val) {
                // Move to the right subtree
                root = root.right;
            } else {
                // If the value of p is smaller,
                // move to the left subtree
                // Update the successor to the
                // current root and traverse left
                successor = root;
                root = root.left;
            }
        }

        // Return the inorder successor node
        return successor;
    }

    public TreeNode InorderPredecessor(TreeNode root, TreeNode p)
    {
        TreeNode predecessorNode = null;

        while(root != null)
        {
            if(p.val <= root.val)
            {
                root = root.left;
            }
            else{
                predecessorNode = root;
                root = root.right;
            }
        }

        return predecessorNode;
    }
}