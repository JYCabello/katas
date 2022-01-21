namespace AnagramsKata;

public class AnagramBuilder
{
    public IEnumerable<string> Get(string word)
    {
        var result = new List<string>();

        for (var i = 0; i < word.Length; i++)
        {
            var character = word[i];
            var subPalindromes = Get(WithoutChar(word, i));
            foreach (var subPalindrome in subPalindromes)
                result.Add($"{character}{subPalindrome}");
        }

        if (word.Length == 1)
            result.Add(word);

        return result;

        static string WithoutChar(string s, int index)
        {
            var pre = s.Substring(0, index);
            var post = s.Length < index + 1 ? "" : s.Substring(index + 1);
            return $"{pre}{post}";
        }
    }
}
