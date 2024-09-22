public class MergeKSortedList
{

    //Approach 1 - Divide & Conquer
    public ListNode MergeKLists1(ListNode[] lists) {
       
        if(lists == null || lists.Length == 0)
            return null;

        int last = lists.Length -1;
        while(last != 0)
        {
            int i = 0;
            int j = last;
            while(i < j)
            {
                lists[i] = MergeLists(lists[i], lists[j]);
                i++;
                j--;
            }

            if(i >= j)
                last = j;
        }   
        return lists[0];
    }

     public static ListNode MergeLists(ListNode a, ListNode b)
    {
        if(a== null)
            return b;
        if(b == null)
            return a;
        ListNode result;
        if(a.val <= b.val)
        {
            result = a;
            result.next = MergeLists(a.next, b);
        }
        else
        {
            result = b;
            result.next = MergeLists(a, b.next);
        }
        return result;
    }


    //Approach 2 - minHeap Based or priprity Q based.
    public ListNode MergeKLists(ListNode[] lists) 
    {
        var pq = new PriorityQueue<ListNode, int>();

        for (int i = 0; i < lists.Length; i++)
        {
            if (lists[i] != null) {
                pq.Enqueue(lists[i], lists[i].val);
            }
        }

        ListNode root = new ListNode(0, null);
        var current = root;

        while(pq.Count > 0)
        {
            var node = pq.Dequeue();
            if(node.next != null)
            {
                pq.Enqueue(node.next, node.next.val);
            }
            current.next = new ListNode(node.val);
            current = current.next; 
        }

        return root.next;
    }
}