using System.ComponentModel.DataAnnotations;
using System.Text;

public class TrieFile
{
    [Required]
    public string Name {get; set;}
    public bool IsFile {get; set;}
    public StringBuilder Content = new StringBuilder();
    public Dictionary<string, TrieFile> Children  = new Dictionary<string, TrieFile>();

    public TrieFile Insert(string path, bool isFile)
    {
        TrieFile node = this;
        string[] paths = path.Split('/', StringSplitOptions.TrimEntries);

        for (int I = 0; I < paths.Length; I++)
        {
            string sPath = paths[I];
            if(!node.Children.ContainsKey(sPath))
            {
                node.Children[sPath] =  new TrieFile();
            }
        }
        node.IsFile = isFile;
        if(isFile)
        {
            node.Name = paths[paths.Length - 1];
        }
        return node;
    }

    public TrieFile Search(string path)
    {
        TrieFile node = this;
        string[] paths = path.Split('/', StringSplitOptions.TrimEntries);
        for (int I = 1; I < paths.Length; I++)
        {
            string part = paths[I];
            if (!node.Children.ContainsKey(part)) {
                return null;
            }
            node = node.Children[part];
        }
        return node;
    }
}



public class MemoryFileSystem
{
    TrieFile rootDirectory = new TrieFile();
    
    public List<string> ls(string path)
    {
        if(string.IsNullOrEmpty(path)) return new List<string>();
        List<string> results = new List<string>();
        TrieFile node = rootDirectory.Search(path);

        if(node == null)
            return results;

        if(node.IsFile)
            results.Add(node.Name);
        else
            results.AddRange(node.Children.Keys);

        results.Sort();
        return results;
    }

    public void mkdir(string path)
    {
        if(string.IsNullOrEmpty(path)) return;
        rootDirectory.Insert(path,false);        
    }

    public void addContentToFile(string path, string content)
    {
        TrieFile node = rootDirectory.Insert(path, true);
        node.Content.Append(content);        
    }

    public string readContentFromFile(string path)
    {
        TrieFile node = rootDirectory.Search(path);
        if(node != null && node.IsFile)
            return node.Content.ToString();
        return "";
    }   
}

/*
 * FileSystem obj = new FileSystem();
 * List<String> param_1 = obj.ls(path);
 * obj.mkdir(path);
 * obj.addContentToFile(filePath, content);
 * String param_4 = obj.readContentFromFile(filePath);
 */