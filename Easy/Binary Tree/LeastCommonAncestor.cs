

using System.Security.Cryptography;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class LeastCommonAncestor {

    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }

  public void Run(){
    TreeNode treeNode = new TreeNode (6) {left = new TreeNode(2), right = new TreeNode(8) };
    _ = LowestCommonAncestor(treeNode, new TreeNode(2), new TreeNode(8)); 
  }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        while(root != null){
            if(root.val > p?.val && root.val > q?.val){ //if P & Q nodes are lesser than root, go left
                root = root.left;
            }
            else if(root.val < p?.val && root.val < q?.val){ //if P & Q nodes are greater than root, go right
                root = root.right;
            }
            else{
                return root;
            }
        }
        return null;
    }
}