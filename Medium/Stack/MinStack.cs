public class MinStack {
    long min = long.MaxValue;
    Stack<long> ints;
    public MinStack() {
        ints = new Stack<long>();
    }
    
    public void Push(long val) {
        if(ints.Count == 0){
            min = val;
            ints.Push(val);
        }
        else{
            if(val < min){
                ints.Push(2 * val - min);
                min = val;
            }
            else{
                ints.Push(val);
            }
        }
    }
    
    public void Pop() {
        if(ints.Count > 0){
            var val = ints.Pop();
            if(val < min){
                min = 2*min - val;
            }
        }
    }
    
    public int Top() {
        var peeked = ints.Peek();
        if(peeked < min){
            return  Convert.ToInt32(min);
        }
        else{
            return Convert.ToInt32(peeked);
        }
    }
    
    public int GetMin() {
        return  Convert.ToInt32(min);
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */