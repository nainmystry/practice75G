public class ConvertSortedArrayToBST
{
    public TreeNode SortedArrayToBST(int[] nums) {
        var root = CreateTree(nums, 0, nums.Length - 1);
        return root;
    }

    public TreeNode CreateTree(int[] nums, int start, int end)
    {
        if (start > end) 
        return null;
        
        int mid = (start + end) / 2;
        return new TreeNode(nums[mid], CreateTree(nums, start, mid - 1), CreateTree(nums, mid + 1, end));
    }
}