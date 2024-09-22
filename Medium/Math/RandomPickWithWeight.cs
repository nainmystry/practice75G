public class RandomPickWithWeight
{
    //Revise
    //Randomization Problem

    private Random random;
    private int[] cumulativeWeight;
    
    public RandomPickWithWeight(int[] w) {
        random = new Random();
        cumulativeWeight = new int[w.Length];

        cumulativeWeight[0] = w[0];
        for (int I = 1; I < w.Length; I++)
        {
            cumulativeWeight[I] = cumulativeWeight[I - 1] + w[I];
        }
    }
    
    public int PickIndex() {
        int totalWeight = cumulativeWeight[cumulativeWeight.Length - 1];
        int randomVal = random.Next(0,totalWeight);
        int left = 0, right = cumulativeWeight.Length - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (randomVal >= cumulativeWeight[mid])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }        
        return left;
    }
}