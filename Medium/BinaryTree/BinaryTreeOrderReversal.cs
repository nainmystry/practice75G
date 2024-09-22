public class BinaryTreeOrderReversal
{

    //BFS Traversal Iterative Approach
    public IList<IList<int>> LevelOrder(TreeNode root) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        var res = new List<IList<int>>();
        if(root == null){
            return res;
        }

        queue.Enqueue(root);
        while(queue.Count > 0){
            List<int> levels = new List<int>();
            
            int count = queue.Count; //Nodes present in Queue            
            for (int I = 0; I < count; I++) //for all the nodes in queue, add child nodes & remove parent one's
            {
                var node = queue.Dequeue();
                levels.Add(node.val);
                if(node.left != null){
                    queue.Enqueue(node.left);
                }
                if(node.right != null){
                    queue.Enqueue(node.right);
                }
            }
            res.Add(levels);
        }
        return res;
    }
}