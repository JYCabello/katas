namespace AnagramsKata;

public class AnagramBuilder
{
    public IEnumerable<string> Get(string word)
    {
        if (word.Length == 2)
            return new List<string> { word, $"{word[1]}{word[0]}" };
        if (word == "")
            return new List<string>();
        return new List<string> { word };
    }
}
