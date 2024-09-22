public class ReorderList1
{
    public void ReorderList(ListNode head) {
        if(head == null) return;

        var middleNode = GetMiddleNode(head);
        var middleHead = ReverseNodes(middleNode.next);
        middleNode.next = null;

        ListNode c1 = head;
        ListNode c2 = middleHead;
        ListNode f1 = null;
        ListNode f2 = null;

        while (c1 != null && c2 != null) {
            // Backup
            f1 = c1.next;
            f2 = c2.next;

            // Linking
            c1.next = c2;
            c2.next = f1;

            // Move
            c1 = f1;
            c2 = f2;
        }
    }

    private ListNode ReverseNodes(ListNode node)
    {
        ListNode forw =null;
        ListNode prev =null;
        ListNode curr = node;
        while(curr != null)
        {
            forw = curr.next;
            curr.next = prev;
            prev = curr;
            curr = forw;
        }
        return prev;
    }
    private ListNode GetMiddleNode(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;
        while(fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }
}