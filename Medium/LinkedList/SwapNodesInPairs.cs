public class SwapNodesInPairs
{
    public ListNode SwapPairs(ListNode head) {
        ListNode dum = new ListNode(0);
        dum.next = head;
        ListNode prev = dum;
        while(prev.next != null && prev.next.next != null)
        {
            ListNode first = prev.next;
            ListNode second = prev.next.next;

            first.next = second.next;
            second.next = first;
            
            prev.next = second;
            prev = first;
        }
        return dum.next;
    }

    //Two Pointers Approach
    public ListNode SwapPairsTP(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }
        
        ListNode newHead = head.next;
        ListNode prev = null;
        ListNode current = head;
        
        while (current != null && current.next != null) {
            ListNode first = current;
            ListNode second = current.next;
            
            // Swap first and second
            first.next = second.next;
            second.next = first;
            
            // Link with previous pair
            if (prev != null) {
                prev.next = second;
            }
            
            // Move to the next pair
            prev = first;
            current = first.next;
        }
        
        return newHead;
    }
}