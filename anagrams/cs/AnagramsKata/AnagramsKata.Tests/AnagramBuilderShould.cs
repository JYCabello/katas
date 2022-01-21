using System.Collections.Generic;
using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace AnagramsKata.Tests;

public class AnagramBuilderShould
{
    [Fact(DisplayName = "Empty should return an empty collection")]
    public void Null()
    {
        var builder = new AnagramBuilder();
        var result = builder.Get("");
        Assert.Empty(result);
    }

    [Property(DisplayName = "One letter should return a collection with that letter")]
    public void OneLetter(char letter)
    {
        var builder = new AnagramBuilder();
        var result = builder.Get(letter.ToString());
        Assert.Equal(new List<string> { letter.ToString() }, result);
    }
}
