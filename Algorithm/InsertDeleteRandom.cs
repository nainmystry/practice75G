public class RandomizedSet1
{
    //can be implemented with or without list.
    //List<int> nums;
    Dictionary<int, int> numMap;
    private Random rand;
    //Initializes the RandomizedSet object.
    public RandomizedSet1() {
     //nums = new List<int>();
     numMap = new Dictionary<int, int>();
     rand = new Random();   
    }
    
    // Inserts an item val into the set if not present. 
    // Returns true if the item was not present, false otherwise.
    public bool Insert(int val) {
        if(numMap.TryGetValue(val, out var value))
        {
            return false;
        }

        //nums.Add(val);
        numMap[val] = 0;
        return true;
    }
    
    // Removes an item val from the set if present.
    // Returns true if the item was present, false otherwise.
    /*
    If the element is not in the set, return false.
    Else, find the index of the element to be removed.
    Swap the element with the last element in the nums list.
    Update the index of the last element in the numToIndex dictionary.
    Remove the last element from the nums list and remove the element from numToIndex.
    Return true to indicate that the removal was successful.
    */
    public bool Remove(int val) {
        if(!numMap.TryGetValue(val, out var value))
        {
            return false;
        }

        //int lastelement = nums[nums.Count - 1];
        int removeIndex = numMap[val];

        //nums[removeIndex] = lastelement;
        //numMap[lastelement] = removeIndex;

        //nums.RemoveAt(nums.Count - 1);
        numMap.Remove(val);

        return true;
    }
    
    // Returns a random element from the current set of elements (it's guaranteed that at least one element exists when this method is called).
    // Each element must have the same probability of being returned.
    public int GetRandom() {
        int randomIndex = rand.Next(numMap.Count);
        //return nums[randomIndex];
        return numMap.ElementAt(randomIndex).Key;
        //return elem.Key;
    }
}


public class RandomizedSet{

    private HashSet<int> nums;
    private Random random;
    public RandomizedSet()
    {
        nums = new HashSet<int>();
        random = new ();
    }

    public bool Insert(int val) {
        if(nums.Contains(val))
        {
            return false;
        }
        
        nums.Add(val);
        return true;
    }
    
    public bool Remove(int val) {
        if(!nums.Contains(val))
        {
            return false;
        }

        nums.Remove(val);
        return true;
    }
    
    public int GetRandom() {
        var randomIndex = random.Next(nums.Count);
        return nums.ElementAt(randomIndex);
    }
}