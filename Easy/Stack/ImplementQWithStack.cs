public class MyQueue {
    private Stack<int> stack1;
    private Stack<int> stack2;
    public MyQueue() {
        stack1 = new ();
        stack2 = new ();
    }
    
    public void Push(int x) {
        stack1.Push(x); //Adds items to stack
    }
    
    public int Pop() {
        if(stack2.Count == 0){ //ensures oldest elements are at the top
            while(stack1.Count > 0){
                stack2.Push(stack1.Pop());
            }
        }
        return stack2.Pop(); //return the element
    }
    
    public int Peek() {
        if(stack2.Count == 0){ //ensures oldest elements are at the top
            while(stack1.Count > 0){
                stack2.Push(stack1.Pop());
            }
        }

        return stack2.Peek(); //return the element
    }
    
    public bool Empty() {
        return stack1.Count == 0 && stack2.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */