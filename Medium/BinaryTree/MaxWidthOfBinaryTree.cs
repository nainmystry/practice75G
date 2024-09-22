public class MaxWidthOfBinaryTree
{
    //Failed Too Big Logic
    public int WidthOfBinaryTreeF(TreeNode root) {
        if(root == null) return 0;

        Queue<(TreeNode,int)> nodes = new Queue<(TreeNode, int)>();
        nodes.Enqueue((root,1));
        Dictionary<int,int> levels = new Dictionary<int, int>();
        while(nodes.Count > 0)
        {
            var node = nodes.Dequeue();
            
            if(!levels.ContainsKey(node.Item2))
            {
                levels[node.Item2] = 0;
            }
            levels[node.Item2]++;
            if(node.Item1.left != null)
            {
                nodes.Enqueue((node.Item1.left, node.Item2 + 1));
            }

            if(node.Item1.right != null)
            {
                nodes.Enqueue((node.Item1.right, node.Item2 + 1));
            }
        }   

        var res = levels.Values.GroupBy(x => x).ToList();
        // .Max() % 2 != 0)
        // {
        //     return levels.Values.Max() + 1;
        // }
        return levels.Values.Max();
    }


    //Revise
    public int WidthOfBinaryTree(TreeNode root)
    {
        if(root == null) return 0;

        Queue<(TreeNode, int)> nodes = new Queue<(TreeNode, int)>();
        nodes.Enqueue((root, 1));
        int maxWidth = 0;
        while(nodes.Count > 0)
        {
            int size = nodes.Count;
            int left = nodes.Peek().Item2;
            int right = left;

            for (int i = 0; i < size; i++)
            {
                (TreeNode node, int index) = nodes.Dequeue();
                right = index;

                if (node.left is not null)
                    nodes.Enqueue((node.left, 2 * index));

                if (node.right is not null)
                    nodes.Enqueue((node.right, 2 * index + 1));
            }
            maxWidth = Math.Max(maxWidth, right - left + 1);
        }
        return maxWidth;
    }
}