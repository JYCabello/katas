using System.Collections.Generic;
using System.Linq;
using FsCheck.Xunit;
using Xunit;

namespace AnagramsKata.Tests;

public class AnagramBuilderShould
{
    [Fact(DisplayName = "return an empty collection for empty")]
    public void Empty()
    {
        var builder = new AnagramBuilder();
        var result = builder.Get("");
        Assert.Empty(result);
    }

    [Property(DisplayName = "return a collection with that letter if one letter")]
    public void OneLetter(char letter)
    {
        var builder = new AnagramBuilder();
        var result = builder.Get(letter.ToString());
        Assert.Equal(new List<string> { letter.ToString() }, result);
    }

    [Fact(DisplayName = "return AB and AB for AB")]
    public void AB()
    {
        var builder = new AnagramBuilder();
        var result = builder.Get("AB").ToList();
        result.Sort();
        var expectation = new List<string> { "AB", "BA" };
        expectation.Sort();
        Assert.Equal(expectation, result);
    }

    [Property(DisplayName = "return the word and the inverse for any two letters")]
    public void AnyTwoLetters(char a, char b)
    {
        var builder = new AnagramBuilder();

        var result = builder.Get($"{a}{b}").ToList();
        result.Sort();
        var expectation = new List<string> { $"{a}{b}", $"{b}{a}" };
        expectation.Sort();

        Assert.Equal(expectation, result);
    }

    [Property(DisplayName = "returns the anagrams for any three letters")]
    public void AnyThreeLetters(char a, char b, char c)
    {
        var builder = new AnagramBuilder();

        var result = builder.Get($"{a}{b}{c}").ToList();
        result.Sort();
        var expectation = new List<string>
        {
            $"{a}{b}{c}",
            $"{a}{c}{b}",
            $"{b}{a}{c}",
            $"{b}{c}{a}",
            $"{c}{a}{b}",
            $"{c}{b}{a}"
        };
        expectation.Sort();

        Assert.Equal(expectation, result);
    }
}
