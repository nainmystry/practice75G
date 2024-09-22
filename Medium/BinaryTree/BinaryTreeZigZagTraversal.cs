public class BinaryTreeZigZagTraversal
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        List<IList<int>> nodes = new List<IList<int>>();
        if(root == null) return nodes;
        Queue<TreeNode> fifo = new Queue<TreeNode>();
        fifo.Enqueue(root);
        bool leftToRight = true;
        while(fifo.Count > 0)
        {
            int size = fifo.Count;   
            List<int> rowLevelData = new List<int>();         
            for (int I = 0; I < size; I++)
            {
                TreeNode node = fifo.Dequeue();

                if (leftToRight) {
                    rowLevelData.Add(node.val);
                } else {
                    rowLevelData.Insert(0,node.val);
                }

                if(node.left != null)
                fifo.Enqueue(node.left);
                if(node.right != null)
                fifo.Enqueue(node.right);
            }
            leftToRight = !leftToRight;
            nodes.Add(rowLevelData);
        }
        return nodes;
    }
}