using System.Security.Cryptography;

public class InvertBinaryTree {

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

public void Run(){
    TreeNode treeNode = new TreeNode{val = 4, left = new TreeNode{val = 2, left = new TreeNode{val = 1}, right = new TreeNode{val = 3}}, right = new TreeNode{val = 7, left = new TreeNode{val = 6}, right = new TreeNode{val = 9}}};
    _ = InvertTree(treeNode);
}

    public TreeNode InvertTree(TreeNode root) {
        if (root == null) {
            return null;
        }

        TreeNode invertedTree = new TreeNode(root.val, null, null);

        invertedTree.left = InvertTree(root.right);
        invertedTree.right = InvertTree(root.left);

        return invertedTree;
    }

    public TreeNode Approach2(TreeNode root){
        if(root == null)
        {
            return root;
        }

        TreeNode left = Approach2(root.left);
        TreeNode right = Approach2(root.right);
        root.left = right;
        root.right = left;

        return root;
    }


}