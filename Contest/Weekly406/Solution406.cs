using System.Diagnostics.CodeAnalysis;
using System.Reflection.PortableExecutable;

public class Solution406
{
    public ListNode ModifiedList(int[] nums, ListNode head) {
        if(nums.Length == 0) return head;
        if(head == null) return head;
        HashSet<int> ints = new HashSet<int>(nums);
        ListNode dum = new ListNode(0);
        dum.next = head;
        ListNode prev = dum; 
        ListNode curr = head; 
        while(curr is not null)
        {
            if(ints.Contains(curr.val))
            {
                prev.next = curr.next;
            }
            else{
                prev = curr;
            }

            curr = curr.next;
        }

        return dum.next;
    }

     public string GetSmallestString(string s) {
        char[] oddParity = new char[] {'1','3','5','7','9'};
        char[] evenParity = new char[] {'0','2','4','6','8'};
        if(string.IsNullOrEmpty(s))
        {
            return s;
        }
        var charArray = s.ToCharArray();
        for (int I = 0; I < charArray.Length - 1; I++)
        {
            if(oddParity.Contains(charArray[I]) && oddParity.Contains(charArray[I + 1]))
            {
                if(int.Parse(charArray[I].ToString()) < int.Parse(charArray[I + 1].ToString()))
                {
                    var temp = charArray[I];
                    charArray[I] = charArray[I + 1];
                    charArray[I+1] = temp;
                    break;
                }
            }
            else if (evenParity.Contains(charArray[I]) && evenParity.Contains(charArray[I + 1]))
            {
                if(int.Parse(charArray[I].ToString()) < int.Parse(charArray[I + 1].ToString()))
                {
                    var temp = charArray[I];
                    charArray[I] = charArray[I + 1];
                    charArray[I+1] = temp;
                    break;
                }
            }
        }

        return new string(charArray);
    }


    public int MinimumCost(int m, int n, int[] horizontalCut, int[] verticalCut) {
        int totalCuts = horizontalCut.Length + verticalCut.Length;

        var pq = new PriorityQueue<Cut,int>();

        for (int I = 0; I < horizontalCut.Length; I++)
        {
            pq.Enqueue(new Cut(horizontalCut[I], 'H'), -horizontalCut[I]);
        }

        for (int I = 0; I < verticalCut.Length; I++)
        {
            pq.Enqueue(new Cut(verticalCut[I], 'V'), -verticalCut[I]);
        }

        int currentHorizontalPieces = 1;
        int currentVerticalPieces = 1;
        int totalCost = 0;

        while(pq.Count > 0)
        {
            var cut = pq.Dequeue();

            if(cut.Type == 'H')
            {
                totalCost += cut.Cost * currentVerticalPieces;
                currentHorizontalPieces++;
            }
            else
            {
                totalCost += cut.Cost * currentHorizontalPieces;
                currentVerticalPieces++;
            }
        }

        return totalCost;
    }

    class Cut{
        public int Cost { get; }
        public char Type { get; }

        public Cut(int cost, char type)
        {
            Cost = cost;
            Type = type;
        }
    }

}