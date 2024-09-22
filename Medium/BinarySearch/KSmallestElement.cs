public class KSmallestElement
{
    private int count = 0;
    private int kthVal = 0;
    public int KthSmallest(TreeNode root, int k) {
        traversBST(root, k);
        return kthVal;
    }

    //To find the smallest element, we need to first check the left tree.
    //Since in BST, Left is the smallest node than other 2, then go for right node.
    //Reason, count is getting incremented after traversing to the bottom most left node.
    private void traversBST(TreeNode root, int k)
    {
        if(root == null) return;
        traversBST(root.left, k);
        count++;
        if(k == count)
        {
            kthVal = root.val;
            return;
        }
        traversBST(root.right,k);        
    }
}