public class ConstructBTbyArray
{
    //Revise 

    //Construct a binary tree from inorder and preorder traversal
    //Inorder = left -> root -> right
    //PreOrder = root -> left -> right
    //PostOrder = left -> right -> root

    //First element of preorder array is the root element of Tree.
    private Dictionary<int, int> inorderIndexMap;
    
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        inorderIndexMap = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++) {
            inorderIndexMap[inorder[i]] = i;
        }
        return BuildSubTree(preorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
    }
    
    private TreeNode BuildSubTree(int[] preorder, int preStart, int preEnd, int inStart, int inEnd) {
        if (preStart > preEnd || inStart > inEnd) return null;
        
        // The first element in preorder is the root of the subtree
        int rootVal = preorder[preStart];
        TreeNode root = new TreeNode(rootVal);
        
        // Find the root in inorder array
        int inRootIndex = inorderIndexMap[rootVal];
        
        // Calculate the size of the left subtree
        int leftTreeSize = inRootIndex - inStart;
        
        // Build left and right subtrees recursively
        root.left = BuildSubTree(preorder, preStart + 1, preStart + leftTreeSize, inStart, inRootIndex - 1);
        root.right = BuildSubTree(preorder, preStart + leftTreeSize + 1, preEnd, inRootIndex + 1, inEnd);
        
        return root;
    }
}