public class RemoveKthNodefromEnd
{
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        int size = 0;
        ListNode temp, beforeRemovedNode;
        temp = head;
        beforeRemovedNode = null;
        while(temp != null)
        {
           temp = temp.next;
           size++;
        }   
        if(size == 1) return null;
        else if(size == n) return head.next;
        temp = head;
        while(size != n)
        {
            beforeRemovedNode = temp;
            temp = temp.next;
            size--;
        }

        beforeRemovedNode.next = temp.next;
        return head;
    }
}