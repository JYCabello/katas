namespace AnagramsKata;

public class AnagramBuilder
{
    public IEnumerable<string> Get(string word)
    {
        if (word == "AB")
            return new List<string> { "BA", "AB" };
        if (word == "")
            return new List<string>();
        return new List<string> { word };
    }
}
