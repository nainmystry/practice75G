using System.Globalization;

public class ContainerWithMostWater
{
    //Two Pointers
    public int MaxArea(int[] height) {
        if(height.Length == 0) return 0;

        int maxValue = int.MinValue;
        for (int I = 0; I < height.Length - 1; I++)
        {
            for (int II = I+1; II < height.Length; II++)            
            {
                var water = (II-I) * Math.Min(height[II],height[I]);
                maxValue = Math.Max(maxValue, water);
            }
        }
        return maxValue;
    }

    public int MaxArea2(int[] height){
        int i = 0,j = height.Length - 1, mx = int.MinValue;
    	while(i < j)
    	{
    		int water = (j-i)* Math.Min(height[i],height[j]);
    		mx = Math.Max(mx,water);
    		if(height[i] < height[j])
    		    i++;
    		else
    		    j--;
    	}	
	    return mx;

    }
}