public class OddEvenLinkedList
{
    public ListNode OddEvenList(ListNode head) {
        if(head == null) return head;
        ListNode odd = head;
        ListNode even = head.next;
        ListNode evenhead = even;
        while(even is not null && even.next is not null)
        {
            odd.next = odd.next.next;
            even.next = even.next.next;

            odd = odd.next;
            even = even.next;
        }

        odd.next = evenhead;
        return head;
    }
}