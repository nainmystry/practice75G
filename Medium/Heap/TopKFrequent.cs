
//Rare
//check the comparer logic
public class TopKFrequents 
{
    public IList<string> TopKFrequent(string[] words, int k) {
        var frequencyMap = new Dictionary<string, int>();

        foreach(var word in words)
        {
            if(frequencyMap.ContainsKey(word))
            {
                frequencyMap[word]++;
            }
            else
            {
                frequencyMap.Add(word,1);
            }
        }
        
        PriorityQueue<string, KeyValuePair<string, int>> maxHeap = new(new NameComparer());
        
        foreach(KeyValuePair<string, int> entry in frequencyMap)
        {
           maxHeap.Enqueue(entry.Key, entry);
        }

        List<string> result = new List<string>();
        
        int i = 0;
        while(i < k && maxHeap.Count > 0) {
            string word = maxHeap.Dequeue();
            result.Add(word);
            i++;    
        }   
        return result;
    }
    
    public class NameComparer: IComparer<KeyValuePair<string, int>>
	{
		public int Compare(KeyValuePair<string, int> x, KeyValuePair<string,int> y) => 
			(x.Value == y.Value) ? (x.Key.CompareTo(y.Key)) : (y.Value-x.Value);
	}
// Basics of Comparer in Priority Queue
// A comparer is a method or a function that takes two elements as input and returns an integer:

// Negative Value (< 0): Indicates the first element is less than the second element, hence should come first in the heap.
// Zero (= 0): Indicates both elements are equal in terms of ordering.
// Positive Value (> 0): Indicates the first element is greater than the second element, hence should come after the second element in the heap.
// The priority queue then uses this comparison result to arrange the elements so that the one with the highest priority is at the root of the heap.
}