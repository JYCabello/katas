namespace AnagramsKata;

public class AnagramBuilder
{
    public IEnumerable<string> Get(string word)
    {
        var result = new List<string>();
        if (word.Length == 0)
            return result;
        result.Add(word);
        if (word.Length == 2)
            result.Add($"{word[1]}{word[0]}");
        return result;
    }
}
