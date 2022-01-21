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
}
