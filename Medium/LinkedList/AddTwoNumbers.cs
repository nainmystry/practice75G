using System.Security.Cryptography;
using System.Text;

public class AddTwoNumbersLL
{
    //Un accepted Approach
    public ListNode AddTwoNumbers1(ListNode l1, ListNode l2) {
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        
        // Convert l1 to a string in reversed order
        while (l1 != null) {
            sb1.Insert(0, l1.val);
            l1 = l1.next;
        }
        
        // Convert l2 to a string in reversed order
        while (l2 != null) {
            sb2.Insert(0, l2.val);
            l2 = l2.next;
        }
        
        // Parse the numbers
        long num1 = 0, num2 = 0;
        if (sb1.Length > 0) {
            long.TryParse(sb1.ToString(), out num1);
        }
        if (sb2.Length > 0) {
            long.TryParse(sb2.ToString(), out num2);
        }
        
        // Add the numbers
        long num = num1 + num2;
        
        // Convert the sum back to a reversed linked list
        char[] charArr = num.ToString().ToCharArray();
        Array.Reverse(charArr);
        
        ListNode head = new ListNode(0);
        ListNode current = head;
        foreach (char c in charArr) {
            var node = new ListNode(c - '0');
            current.next = node;
            current = current.next;
        }
        
        return head.next;
    }

    //Practice. LSB to MSB Calculation
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode res = new(0, null);
        ListNode cur = res;

        int carry = 0;
        while (l1 is not null || l2 is not null || carry is not 0)
        {
            int sum = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
            carry = sum / 10; 
            cur.next = new(sum % 10, null);
            cur = cur.next;
            l1 = l1?.next;
            l2 = l2?.next;
        }

        return res.next;
    }
}