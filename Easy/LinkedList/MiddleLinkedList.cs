
public class MiddleLinkedNode {

    public void Run(){
        ListNode list1 = new ListNode(1){next = new ListNode(2){next = new ListNode(4){next = null}}};
        var res = MiddleNode(list1);
        string di = "";
    }

    public ListNode MiddleNode(ListNode head) {
        ListNode slowPointer = head;
        ListNode fastPointer = head;
        // int pointer = 0;
        while(fastPointer != null && fastPointer.next != null && slowPointer != null){
            slowPointer = slowPointer.next;
            fastPointer = fastPointer.next.next;
            // pointer++;
        }
        return slowPointer;
    }
}