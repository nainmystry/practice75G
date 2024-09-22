
 
public class DiameterOfTree {
    public int diameter = 0;
    public int DiameterOfBinaryTree(TreeNode root) {
        TraverseRoot(root);
        return diameter;
    }

    public void Run(){
        //var res = DiameterOfBinaryTree(new TreeNode(1){left = new TreeNode(2){left = new TreeNode(4), right = new TreeNode(5)},right = new TreeNode(3)});
        var res = DiameterOfBinaryTree(new TreeNode(1){left = new TreeNode(2)});
        //return ; 
    }

    public int TraverseRoot(TreeNode root){
        if(root == null)
            return 0;
        int left = TraverseRoot(root.left);
        int right = TraverseRoot(root.right);
        if((left + right) > diameter){
            diameter = left + right;
        }
        return Math.Max(left, right) + 1;
    }
}