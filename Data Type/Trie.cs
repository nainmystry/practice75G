public class TrieNode
{
  public bool IsEndOfWord = false;
  public Dictionary<char, TrieNode> Children { get; set; }

  public TrieNode()
  {
    Children = new Dictionary<char, TrieNode>();
    IsEndOfWord = false;
  }
}

public class Trie
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode trieNode = root;
        foreach (char c in word)
        {
            if(!trieNode.Children.ContainsKey(c))
            {
                trieNode.Children[c] = new TrieNode();
            }
            trieNode = trieNode.Children[c];
        }
        trieNode.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        TrieNode node = SearchPrefix(word);
        return node != null && node.IsEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        TrieNode node = SearchPrefix(prefix);
        return node != null;
    }

    private TrieNode SearchPrefix(string prefix)
    {
        TrieNode trieNode = root;
        foreach (char c in prefix)
        {
            if(!trieNode.Children.ContainsKey(c))
            {
                return null;
            }
            trieNode = trieNode.Children[c];
        }
        return trieNode;
    }


}
