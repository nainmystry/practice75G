public class RightSideViews
{
    
    public IList<int> RightSideView(TreeNode root) {
        List<int> ints = new List<int>();    
        if(root == null)
        {
            return ints;
        }
        DFS(root, 0, ints);
        return ints;
    }

    private void DFS(TreeNode node, int depth, List<int> res){
        if(node == null)
        return;

        if(depth == res.Count)
        res.Add(node.val);

        DFS(node.right, depth + 1, res);  //Visit right nodes
        DFS(node.left, depth + 1, res);   //Visit left nodes
    }
}