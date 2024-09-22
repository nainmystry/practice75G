public class ContainsDuplicate
{
    public bool Run(int[] nums){
        return nums.Distinct().Count() != nums.Length;
    }
}