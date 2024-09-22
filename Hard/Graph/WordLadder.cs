public class WordLadder
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var set = wordList.ToHashSet();

        if(!set.Contains(endWord)) return 0;

        if(beginWord == endWord) return 1;

          // Queue for BFS, storing tuples of (currentWord, currentLength)
        Queue<(string, int)> queue = new Queue<(string, int)>();
        queue.Enqueue((beginWord, 1));

        while(queue.Count > 0)
        {
            var (currW, currI) = queue.Dequeue();

            for (int I = 0; I < currW.Length; I++)
            {
                char[] wordArray = currW.ToCharArray();

                for (char c = 'a'; c <= 'z'; c++)
                {
                    wordArray[I] = c;
                    var newWord = new string(wordArray);
                    if(newWord == endWord)
                        return currI + 1;

                    if(set.Contains(newWord))
                    {
                        queue.Enqueue((newWord, currI + 1));
                        set.Remove(newWord);
                    } 
                }
            }
        }

        return 0;
    }
}