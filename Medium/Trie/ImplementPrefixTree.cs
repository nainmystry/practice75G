public class ImplementPrefixTree
{
    TrieNode root = null;
    public class TrieNode()
    {   
        //address to connections
        public TrieNode[] connections = new TrieNode[26];
        public bool IsLastLetter = false;
    }

    public ImplementPrefixTree() {
        root = new TrieNode();
    }
    
    public void Insert(string word) {
        TrieNode prev = root;
        foreach (char c in word)
        {
            TrieNode t;
            if(prev.connections[c-'a'] == null){
                t = new TrieNode();
                prev.connections[c-'a'] = t;
            }
            else{
                t = prev.connections[c-'a'];
            }
            prev = t;
        }
        prev.IsLastLetter = true;
    }
    
    public bool Search(string word) {
        TrieNode prev = root;
        for(int i=0; i < word.Length; i++)
        {
            if(prev != null && prev.connections[word[i]-'a']==null)
            {
                return false;
            }
            prev = prev.connections[word[i]-'a'];
        }
        return prev.IsLastLetter;
    }
    
    public bool StartsWith(string prefix) {
        TrieNode prev = root;
        foreach(char ch in prefix)
        {
            if(prev.connections[ch-'a'] == null)
                return false;
            prev = prev.connections[ch-'a'];
        }
        return true;
    }    
}


/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */