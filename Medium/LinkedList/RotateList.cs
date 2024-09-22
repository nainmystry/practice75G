public class ROtateList
{
    public ListNode RotateRight(ListNode head, int k) {
        if(k==0 || head == null || head.next == null) return head;

        int n = 0;
        var curr = head;
        n++;
        while(curr.next != null)
        {
            curr = curr.next;
            n++;
        }
        int rotations = k % n;
        if(rotations == 0) return head;

        int newHead = n - rotations;
        curr.next = head;
        while(newHead-- > 0)
        {
            curr = curr.next;
        }

        ListNode newNode = curr.next;
        curr.next = null;
        return newNode;
    }
}