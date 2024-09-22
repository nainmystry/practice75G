public class LargestRectangleHistogram
{
    //VIMP How did we calculate width, height & area?
    public int LargestRectangleArea(int[] heights) {
        if(heights.Length == 1) return heights[0];

        int len = heights.Length, max = 0;
        var stack = new Stack<int>();
        for (int I = 0; I <= len; I++)
        {
            var height = I < len ? heights[I] : 0;
            while(stack.Count > 0 && heights[stack.Peek()] > height)
            {
                int currheight = heights[stack.Pop()];
                int width = (stack.Count == 0) ? I : I - stack.Peek() - 1;
                max = Math.Max(max, currheight * width);
            }
            stack.Push(I);
        }
        return max;
    }
}