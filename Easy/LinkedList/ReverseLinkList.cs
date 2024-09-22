/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class RLL {

    public ListNode ReverseList(ListNode head) {
        ListNode resultNode = null;
        while(head != null)
        {
            resultNode = new ListNode(head.val, resultNode);
            head = head.next;
        }
        return resultNode;
    }

    public void Run() {
        ReverseList(new ListNode (1) {next = new ListNode(2) {next = new ListNode(3)}});
    }

    // private ListNode RL(ListNode rootNode){
    //     if(rootNode.next == null)
    //     {
    //         return rootNode;
    //     }
    //     var root = RL(rootNode.next);
    //     root.next = rootNode;
    //     return root;
    // }
}