//VVIMP

public class FreqStack {
private int maxFreq = 0;
private Dictionary<int,int> intMap;
private Dictionary<int,Stack<int>> freqMap;
    public FreqStack() {
        intMap = new Dictionary<int, int>();
        freqMap = new Dictionary<int, Stack<int>>();
        maxFreq = 0;
    }
    
    public void Push(int val) {
        if(!intMap.ContainsKey(val))
        intMap[val] = 0;

        intMap[val]++;
        var currFreq = intMap[val];
        maxFreq = Math.Max(maxFreq, currFreq);
        
        if(!freqMap.ContainsKey(currFreq))
        freqMap[currFreq] = new Stack<int>();

        freqMap[currFreq].Push(val);
    }
    
    public int Pop() {
        if(maxFreq == 0)
        return 0;
        var res = freqMap[maxFreq].Pop();        
        intMap[res]--;
        if (freqMap[maxFreq].Count == 0)
        {
            maxFreq--;
        }
        return res;
    }
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(val);
 * int param_2 = obj.Pop();
 */