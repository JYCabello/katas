using Xunit;

namespace GameOfLife.Test;

public class WorldShould
{
    [Fact(DisplayName = "kill a single cell")]
    public void Test1()
    {
        var world = new World(new []
        {
            new [] { true }
        });
        var result = world.NextState();
        Assert.False(result[0][0]);
    }

}
