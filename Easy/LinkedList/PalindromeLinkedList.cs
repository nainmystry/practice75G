public class PalindromeLinkedList
{
    public bool IsPalindrome(ListNode head) {
        var slow = head;
        var fast = head;
        ListNode prev = null;
        while(fast != null && fast.next != null)
        {
            fast = fast.next.next;

            //Reversing the array untill half
            //prev = first half, slow = second half
            ListNode next = slow.next;
            slow.next = prev;
            prev = slow;
            slow = next;
        }    

        if(fast != null)
            slow = slow.next;

        while (slow != null)
        {
            if (slow.val != prev.val)
                return false;

            slow = slow.next;
            prev = prev.next;
        }

        return true;
    } 
}