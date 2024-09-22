
using System.Runtime.CompilerServices;

public class BBT {

    public bool IsBalanced(TreeNode root) {
      if(root == null) return true;

      if(Height(root) == -1) return false;
      return true;  
    }

    public int Height(TreeNode root){
        
        if(root == null) return 0;

        int leftHeight = Height(root.left); //get the left most height
        int rightHeight = Height(root.right); //get the right most height

        if(leftHeight == -1 || rightHeight == -1) return -1; //Incase of unbalanced return -1;

        if(Math.Abs(leftHeight - rightHeight) > 1) return -1; //if height more than 1, return -1;

        return Math.Max(leftHeight,rightHeight) + 1; //otherwise, return height of the subtree
    }

    public void Run(){
        //TreeNode root = CreateNode(new int?[]{3,9,20,null,null,15,7});
        var res = IsBalanced(new TreeNode(3){left = new TreeNode(9), right = new TreeNode(20){left = new TreeNode(15), right = new TreeNode(7){left = new TreeNode(3), right = new TreeNode(4)}}});
    }

    private TreeNode CreateNode(int?[] intArray){
        TreeNode root = null;
        TreeNode dummyHead = new TreeNode();
        TreeNode currNode = dummyHead;
        var maxL = intArray.Length;
        int I = 0;
        bool insertLeft = true;
        // while(I < maxL){
        //     TreeNode treeNode = new TreeNode(intArray[I]);
        // }
        return root;
    }
}