public class LRUCache
{
    private readonly Dictionary<int, LinkedListNode<CacheItem>> cacheMap;
    private readonly int maxCapacity = 0;
    private readonly LinkedList<CacheItem> cacheList;
    public LRUCache(int capacity) {
        this.maxCapacity = capacity;
        cacheMap = new Dictionary<int, LinkedListNode<CacheItem>>();
        cacheList = new LinkedList<CacheItem>();
    }
    
    public int Get(int key) {
        if(cacheMap.TryGetValue(key, out var node))
        {
            cacheList.Remove(node);
            cacheList.AddFirst(node);
            return node.Value.Value;
        }
        return -1;
    }
    
    public void Put(int key, int value) {
        if(cacheMap.TryGetValue(key, out var node))
        {
            node.Value.Value = value;
            cacheList.Remove(node);
            cacheList.AddFirst(node);
        }
        else{
            if(cacheMap.Count >= maxCapacity)
            {
                var lastNode = cacheList.Last;
                cacheMap.Remove(lastNode.Value.Key);
                cacheList.RemoveLast();
            }

            var newNode = new LinkedListNode<CacheItem>(new CacheItem(key,value));
            cacheMap.Add(key, newNode);
            cacheList.AddFirst(newNode);
        }
    }

    private class CacheItem{
        public int Key { get; set; }
        public int Value { get; set; }

        public CacheItem(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }
}