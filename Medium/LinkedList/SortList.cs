public class SortLists
{

    //Example of Merge Sort
    //Revise
    public ListNode SortList(ListNode head) {
        if(head == null || head.next == null)
        return head;        

        ListNode mid = GetMid(head);
        ListNode left = head;
        ListNode right = mid.next;
        mid.next = null; // Split the list into two halves

        left = SortList(left);
        right = SortList(right);

        return Merge(left, right);
    }

    private ListNode GetMid(ListNode M)
    {
        if(M == null) return M;

        ListNode slow = M;
        ListNode fast = M.next;
        while(fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }

    private ListNode Merge(ListNode left, ListNode right)
    {
        ListNode dummy = new ListNode(0);
        ListNode tail = dummy;

        while(left != null && right != null)
        {
            if(left.val < right.val)
            {
                tail.next = left;
                left = left.next;
            }
            else
            {
                tail.next = right;
                right = right.next;
            }
            tail = tail.next;
        }
        tail.next = (left != null) ? left : right;
        return dummy.next;
    }
}