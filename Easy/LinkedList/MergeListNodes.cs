
public class Solution {

public void Run(){
    ListNode list1 = new ListNode(1){next = new ListNode(2){next = new ListNode(4){next = null}}};
    ListNode list2 = new ListNode(1){next = new ListNode(3){next = new ListNode(4){next = null}}};    
   var res = MergeTwoLists(list1, list2);
}

//Approach 1
    public ListNode MergeTwoLists1(ListNode list1, ListNode list2) {
        ListNode dummyHead = new ListNode(-1); 
        // Create a dummy node as the starting point
        ListNode current = dummyHead; 
        // Pointer to keep track of the current node

        while (list1 != null && list2 != null) {
            if (list1.val <= list2.val) {
                current.next = list1;
                list1 = list1.next;
            } else {
                current.next = list2;
                list2 = list2.next;
            }
            current = current.next;
        }

        // Attach the remaining nodes if any
        if (list1 != null) {
            current.next = list1;
        } else {
            current.next = list2;
        }

        var res = dummyHead.next;
        return res; 
        // Return the merged list starting from the node after the dummy head

    }

//Approach 2
    public ListNode MergeTwoLists(ListNode node1, ListNode node2) {
        ListNode beginning = new ListNode(-1);
        ListNode start = beginning;

        while (node1 != null || node2 != null) {
            var L1V = node1 != null ? node1.val : int.MaxValue;
            var L2V = node2 != null ? node2.val : int.MaxValue;

            if (L1V < L2V) {
                start.next = node1;
                start = node1;
                node1 = node1.next;
            }
            else {
                start.next = node2;
                start = node2;
                node2 = node2.next;
            }
        }

        return beginning.next;
    }
}
