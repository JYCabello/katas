using System.Collections.Generic;
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
        var result = builder.Get("AB");
        var expectation = new List<string> { "AB", "BA" };
        Assert.Equal(expectation, result);
    }
}
