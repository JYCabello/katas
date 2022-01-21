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
        for (var i = 0; i < word.Length - 1; i++)
        {
            var character = word[i];
            var subPalindromes = Get(WithoutChar(word, i));
            foreach (var subPalindrome in subPalindromes)
                result.Add($"{character}{subPalindrome}");
        }

        return result;

        static string WithoutChar(string s, int index) =>
            "";
    }
}
