public class ReverseNodesInGroup
{
    public ListNode ReverseKGroup(ListNode head, int k) {
        if(head == null || k == 1)
        return head;

        ListNode dumm = new ListNode(0);
        dumm.next = head;

        ListNode cur = dumm, nex = dumm, pre = dumm;
        int count = 0;

        while(cur.next != null)
        {
            cur = cur.next;
            count++;
        }

        while(count >= k)
        {
            cur = pre.next;
            nex = cur.next;
            for (int i = 1; i < k; i++)
            {
                cur.next = nex.next;
                nex.next = pre.next;
                pre.next = nex;
                nex = cur.next;
            }
            pre = cur;
            count -= k;
        }

        return dumm.next;
    }
}