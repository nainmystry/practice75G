
public class WordDictionary {

    public WordDictionaryNode Root { get; set; }

    public WordDictionary() {        
        Root = new WordDictionaryNode();
    }

    public void AddWord(string word) {
        var current = Root;

        foreach (var c in word) {
            if (current.Children[c - 'a'] == null) {
                current.Children[c - 'a'] = new WordDictionaryNode();
            }

            current = current.Children[c - 'a'];
        }

        current.IsWord = true;
    }

    public bool Search(string word) {
        return Search(word, Root);
    }

    public bool Search(string word, WordDictionaryNode node) {
        for (var i = 0; i < word.Length; i++) {
            if (word[i] == '.') {
                foreach (var n in node.Children) {
                    if (n != null) {
                        var t = Search(word[(i + 1)..], n);

                        if (t) {
                            return true;
                        }
                    }
                }

                return false;
            }
            else {
                if (node.Children[word[i] - 'a'] == null) {
                    return false;
                }

                node = node.Children[word[i] - 'a'];
            }
        }

        return node.IsWord;
    }
}

public class WordDictionaryNode {
    public bool IsWord { get; set; }

    public WordDictionaryNode[] Children { get; set; }

    public WordDictionaryNode() {
        Children = new WordDictionaryNode[26];
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */


//TLE 
public class WordDictionary12
{
   Dictionary<int, HashSet<string>> strings {get; set;}
    public WordDictionary12() {
      strings = new Dictionary<int, HashSet<string>>();
    }
    
    public void AddWord(string word) {
        var n = word.Length;
        if(!strings.ContainsKey(n))
        {
            strings[n] = new HashSet<string>();
        }
        strings[n].Add(word);
    }
    
    public bool Search(string word) {
        var n = word.Length;
        if(strings.ContainsKey(n))
        {
            var set = strings[n];
            if(set.Any(x=> x == word))
            return true;
            else{
                if(word.Contains("."))
                {
                foreach (string s in set)
                {
                    bool containsKey = true;
                    for (int I = 0; I < word.Length; I++)
                    {
                        if (s[I] == '.' || word[I] == '.')
                        continue;

                        if (s[I] != word[I])
                        {
                            containsKey = false;
                            break;
                        }
                    }

                    if (containsKey)
                    return true;
                }
                return false;
                }
                else
                return false;
           }
        }
        else
        return false;
    }

}