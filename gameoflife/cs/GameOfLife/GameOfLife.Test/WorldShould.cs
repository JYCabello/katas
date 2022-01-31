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
        world.NextState();
        Assert.False(world.GetBoard()[0][0]);
    }

    [Fact(DisplayName = "kill a single cell in a row")]
    public void Test2()
    {
        var world = new World(new []
        {
            new [] { true, true }
        });
        world.NextState();
        Assert.False(world.GetBoard()[0][1]);
    }

    [Fact(DisplayName = "keeps a cell alive when it has two living neighbors")]
    public void Test3()
    {
        var world = new World(new []
        {
            new [] { true, true, true }
        });
        world.NextState();
        Assert.True(world.GetBoard()[0][1]);
    }
}
