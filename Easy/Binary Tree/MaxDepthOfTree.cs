
public class MaxDepthTree {

    public int MaxDepth(TreeNode root) {
        if(root == null){
            return 0;
        }
        var left = MaxDepth(root.left);
        var right = MaxDepth(root.right);
        return Math.Max(left, right) + 1;        
    }
}