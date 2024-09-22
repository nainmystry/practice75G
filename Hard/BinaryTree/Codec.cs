using System.Text;

public class Codec
{
    //Serialize-Deserialize TreeNodes

    private const string NullMarker = "#";
    private const string Delimiter = ",";
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
      if(root == null) return string.Empty;  
      StringBuilder stringBuilder = new StringBuilder();
      SerializeDFS(stringBuilder, root); //Inorder serializing
      return stringBuilder.ToString();
    }

    private void SerializeDFS(StringBuilder sb, TreeNode root)
    {
        if(root == null)
        {
            sb.Append(NullMarker).Append(Delimiter);
            return;
        }

        sb.Append(root.val).Append(Delimiter);
        SerializeDFS(sb, root.left);
        SerializeDFS(sb, root.right);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if(string.IsNullOrEmpty(data))
        {
            return null;
        }

        Queue<string> nodes = new Queue<string>(data.Split(new[] {Delimiter}, StringSplitOptions.RemoveEmptyEntries));
        var node = DeserializeHelper(nodes);
        return node;
    }

    private TreeNode DeserializeHelper(Queue<string> nodes)
    {
        if(nodes.Count == 0)
        {
            return null;
        }

        string val = nodes.Dequeue();
        if(val == NullMarker)
        {
            return null;
        }

        TreeNode node = new TreeNode(int.Parse(val));
        node.left = DeserializeHelper(nodes);
        node.right = DeserializeHelper(nodes);

        return node;
    }

}