public class SmallestRangeCoveringKElem
{
    public int[] SmallestRange(IList<IList<int>> nums) {
        PriorityQueue<(int num, int list, int index), int> priorityQueue = new PriorityQueue<(int num, int list, int index), int>();
        int maxVal = int.MinValue;
        (int num, int list, int index) minItem;
        int[] res = new int[] {-100000, 100000};

        for (int I = 0; I < nums.Count; I++)
        {
            var val = nums[I][0];
            priorityQueue.Enqueue((val, I, 0),val);
            maxVal = Math.Max(maxVal, val);
        } 

        int nextNum, numIndex, listIndex;

        while(true)
        {
            minItem = priorityQueue.Dequeue();

            if(res[1] - res[0] > maxVal - minItem.num)
            {
                res[0] = minItem.num;
                res[1] = maxVal;
            }

            listIndex = minItem.list;
            numIndex = minItem.index + 1;
            if(numIndex >= nums[listIndex].Count)
            {
                break;
            }

            nextNum = nums[listIndex][numIndex];
            maxVal = Math.Max(maxVal, nextNum);
            priorityQueue.Enqueue((nextNum, listIndex, numIndex), nextNum);
        }

        return res;
    }
}